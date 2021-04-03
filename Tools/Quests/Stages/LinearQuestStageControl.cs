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
    public partial class LinearQuestStageControl : UserControl
    {
        public Control NextStageControl { get; set; }

        public event EventHandler<NextStageControlRequest> NextControlRequest;

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
    }
}
