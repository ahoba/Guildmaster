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

        public override QuestStage GetNextStage(IEnumerable<Character> characters, IList<Item> provisions, out bool questFailed, out IEnumerable<string> log)
        {
            questFailed = false;

            log = new string[]
            {
                StageEndText.Text
            };

            return null;
        }
    }
}
