using Danke.Characters;
using Danke.Quests;
using Danke.Quests.QuestStages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Quests.Rolls;
using Tools.Util;

namespace Tools.Quests
{
    public partial class BinaryQuestStageControl : UserControl, IQuestStageControl
    {
        public IQuestStageControl FailureStageControl { get; set; }

        public IQuestStageControl SuccessStageControl { get; set; }

        public QuestStage QuestStage => _questStage;

        private BinaryQuestStage _questStage;

        public BinaryQuestStage BinaryQuestStage
        {
            get => _questStage;
            set
            {
                _questStage = value;

                if (_questStage == null)
                {
                    textBoxStartingText.Text = string.Empty;
                    textBoxSuccessText.Text = string.Empty;
                    textBoxFailureText.Text = string.Empty;

                    listBoxTests.DataSource = null;
                }
                else
                {
                    textBoxStartingText.Text = _questStage.StageStartText.Text;
                    textBoxSuccessText.Text = _questStage.SuccessText.Text;
                    textBoxFailureText.Text = _questStage.FailureText.Text;

                    listBoxTests.DataSource = _questStage.Tests;
                }
            }
        }

        public event EventHandler<NextStageControlRequest> FailureControlRequest;

        public event EventHandler<NextStageControlRequest> SuccessControlRequest;

        public BinaryQuestStageControl()
        {
            InitializeComponent();
            comboBoxAddFailureStage.MouseWheel += ComboBox_MouseWheel;
            comboBoxAddSuccessStage.MouseWheel += ComboBox_MouseWheel;
            comboBoxAddFailureStage.DataSource = Enum.GetValues(typeof(QuestStageType));
            comboBoxAddSuccessStage.DataSource = Enum.GetValues(typeof(QuestStageType));
        }

        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            (e as HandledMouseEventArgs).Handled = true;
        }

        private void comboBoxAddFailureStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAddFailureStage.SelectedItem is QuestStageType stageType)
            {
                FailureControlRequest?.Invoke(this, new NextStageControlRequest()
                {
                    StageType = stageType
                });
            }
        }

        private void comboBoxAddSuccessStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAddSuccessStage.SelectedItem is QuestStageType stageType)
            {
                SuccessControlRequest?.Invoke(this, new NextStageControlRequest()
                {
                    StageType = stageType
                });
            }
        }

        private void textBoxStartingText_TextChanged(object sender, EventArgs e)
        {
            if (_questStage != null)
            {
                _questStage.StageStartText.Text = textBoxStartingText.Text;
            }
        }

        private void textBoxSuccessText_TextChanged(object sender, EventArgs e)
        {
            if (_questStage != null)
            {
                _questStage.SuccessText.Text = textBoxSuccessText.Text;
            }
        }

        private void textBoxFailureText_TextChanged(object sender, EventArgs e)
        {
            if (_questStage != null)
            {
                _questStage.FailureText.Text = textBoxFailureText.Text;
            }
        }

        private void buttonNextStageRoll_Click(object sender, EventArgs e)
        {
            if (_questStage != null)
            {
                RollControl rollControl = new RollControl();

                rollControl.Roll = _questStage.NextStageRoll;

                GenericDialogForm dialog = new GenericDialogForm()
                {
                    Control = rollControl
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}
