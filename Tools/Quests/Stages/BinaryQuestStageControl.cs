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
    public partial class BinaryQuestStageControl : UserControl
    {
        public Control FailureStageControl { get; set; }

        public Control SuccessStageControl { get; set; }

        public event EventHandler<NextStageControlRequest> FailureControlRequest;

        public event EventHandler<NextStageControlRequest> SuccessControlRequest;

        public BinaryQuestStageControl()
        {
            InitializeComponent();

            comboBoxAddFailureStage.DataSource = Enum.GetValues(typeof(QuestStageType));
            comboBoxAddSuccessStage.DataSource = Enum.GetValues(typeof(QuestStageType));
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
    }
}
