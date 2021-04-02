using Danke.Characters;
using Danke.Items;
using Danke.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Danke.Quests.QuestStages
{
    [Serializable]
    public class LinearQuestStage : QuestStage
    {
        public virtual QuestStage NextStage { get; set; }

        public virtual RegionText StageEndText { get; set; }

        public override QuestStage GetNextStage(IEnumerable<Character> characters, IList<Item> provisions, out bool questFailed, out IEnumerable<string> log)
        {
            IList<string> logList = new List<string>();

            log = logList;

            if (NextStageRoll.RollType == RollType.SingleCharacter)
            {
                Character character = characters.OrderByDescending(x => x.Stats[(int)NextStageRoll.TestedStat]).First();

                NextStageRoll.TryRoll(character, provisions, out int hpDamage, out int staminaDamage, out IEnumerable<string> rollLog);

                foreach (string s in rollLog)
                {
                    logList.Add(s);
                }

                ApplyDamageToCharacter(character, hpDamage, staminaDamage, logList, out bool isCharacterHealthy);

                if (!isCharacterHealthy)
                {
                    questFailed = true;

                    return null;
                }
            }
            else if (NextStageRoll.RollType == RollType.WholeParty)
            {
                foreach (Character character in characters)
                {
                    NextStageRoll.TryRoll(character, provisions, out int hpDamage, out int staminaDamage, out IEnumerable<string> rollLog);

                    foreach (string s in rollLog)
                    {
                        logList.Add(s);
                    }

                    ApplyDamageToCharacter(character, hpDamage, staminaDamage, logList, out bool isCharacterHealthy);

                    if (!isCharacterHealthy)
                    {
                        questFailed = true;

                        return null;
                    }
                }
            }

            questFailed = false;

            logList.Add(StageEndText.Text);

            return NextStage;
        }
    }
}
