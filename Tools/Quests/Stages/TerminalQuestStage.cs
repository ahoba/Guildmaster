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
    public partial class TerminalQuestStageControl : UserControl, IQuestStageControl
    {
        public QuestStage QuestStage => _questStage;

        private TerminalQuestStage _questStage;

        public TerminalQuestStage TerminalQuestStage
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

                    checkBoxStageFailsQuest.Checked = false;
                }
                else
                {
                    textBoxStartingText.Text = _questStage.StageStartText.Text;
                    textBoxStageEndText.Text = _questStage.StageEndText.Text;

                    listBoxTests.DataSource = _questStage.Tests;

                    checkBoxStageFailsQuest.Checked = _questStage.IsQuestFailure;
                }
            }
        }

        public TerminalQuestStageControl()
        {
            InitializeComponent();
        }

        private void textBoxStartingText_TextChanged(object sender, EventArgs e)
        {
            if (_questStage != null)
            {
                _questStage.StageStartText.Text = textBoxStartingText.Text;
            }
        }

        private void textBoxStageEndText_TextChanged(object sender, EventArgs e)
        {
            if (_questStage != null)
            {
                _questStage.StageEndText.Text = textBoxStageEndText.Text;
            }
        }

        private void checkBoxStageFailsQuest_CheckedChanged(object sender, EventArgs e)
        {
            if (_questStage != null)
            {
                _questStage.IsQuestFailure = checkBoxStageFailsQuest.Checked;
            }
        }
    }
}
