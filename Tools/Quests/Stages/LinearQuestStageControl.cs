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

namespace Tools.Quests
{
    public partial class LinearQuestStageControl : UserControl, IQuestStageControl
    {
        public IQuestStageControl NextStageControl { get; set; }

        public event EventHandler<NextStageControlRequest> NextControlRequest;

        private LinearQuestStage _questStage;

        public LinearQuestStage LinearQuestStage 
        {
            get => _questStage;
            set
            {
                _questStage = value;

                if (_questStage == null)
                {
                    textBoxStartingText.Text = string.Empty;
                    textBoxStageEndText.Text = string.Empty;

                    listBoxTests.DataSource = null;
                }
                else
                {
                    textBoxStartingText.Text = _questStage.StageStartText.Text;
                    textBoxStageEndText.Text = _questStage.StageEndText.Text;

                    listBoxTests.DataSource = _questStage.Tests;
                }
            }
        }

        public QuestStage QuestStage => _questStage;

        public LinearQuestStageControl()
        {
            InitializeComponent();

            comboBoxAddNextStage.DataSource = Enum.GetValues(typeof(QuestStageType));
        }

        private void comboBoxAddNextStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAddNextStage.SelectedItem is QuestStageType stageType)
            {
                NextControlRequest?.Invoke(this, new NextStageControlRequest()
                {
                    StageType = stageType
                });
            }
        }

        private void textBoxStartingText_TextChanged(object sender, EventArgs e)
        {
            if (_questStage != null)
            {
                _questStage.StageStartText.Text = (sender as TextBox).Text;
            }
        }

        private void textBoxStageEndText_TextChanged(object sender, EventArgs e)
        {
            if (_questStage != null)
            {
                _questStage.StageEndText.Text = (sender as TextBox).Text;
            }
        }
    }
}
