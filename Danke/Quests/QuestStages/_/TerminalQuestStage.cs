using Danke.Characters;
using Danke.Items;
using Danke.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Quests.QuestStages
{
    [Serializable]
    public class TerminalQuestStage : QuestStage
    {
        public virtual RegionText StageEndText { get; set; }

        protected override QuestStage InternalGetNextStage(IEnumerable<Character> characters, IList<Item> provisions, IList<string> logList, out bool questFailed)
        {
            questFailed = false;

            logList.Add(StageEndText.Text);

            return null;
        }
    }
}
