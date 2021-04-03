using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Quests
{
    public enum QuestStageType
    {
        None,
        Binary,
        Linear,
        Terminal
    }

    public class NextStageControlRequest : EventArgs
    {
        public QuestStageType StageType { get; set; }
    }
}
