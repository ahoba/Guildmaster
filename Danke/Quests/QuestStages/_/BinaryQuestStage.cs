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
    public class BinaryQuestStage : QuestStage
    {
        public virtual QuestStage SuccessStage { get; set; }

        public RegionText SuccessText { get; set; }

        public virtual QuestStage FailureStage { get; set; }

        public RegionText FailureText { get; set; }

        public override QuestStage GetNextStage(IEnumerable<Character> characters, IList<Item> provisions, out bool questFailed, out IEnumerable<string> log)
        {
            IList<string> logList = new List<string>();

            log = logList;

            if (NextStageRoll.RollType == RollType.SingleCharacter)
            {
                foreach (Character character in characters.OrderByDescending(x => x.Stats[(int)NextStageRoll.TestedStat]))
                {
                    bool rollResult = NextStageRoll.TryRoll(character, provisions, out int hpDamage, out int staminaDamage, out IEnumerable<string> rollLog);

                    foreach (string s in rollLog)
                    {
                        logList.Add(s);
                    }

                    bool isCharacterHealthy;

                    if (rollResult)
                    {
                        ApplyDamageToCharacter(character, hpDamage, staminaDamage, logList, out isCharacterHealthy);

                        if (!isCharacterHealthy)
                        {
                            questFailed = true;

                            return null;
                        }

                        questFailed = false;

                        logList.Add(SuccessText.Text);

                        return SuccessStage;
                    }

                    ApplyDamageToCharacter(character, hpDamage, staminaDamage, logList, out isCharacterHealthy);

                    if (!isCharacterHealthy)
                    {
                        questFailed = true;

                        return null;
                    }
                }

                questFailed = false;

                logList.Add(FailureText.Text);

                return FailureStage;
            }
            else if (NextStageRoll.RollType == RollType.WholeParty)
            {
                foreach (Character character in characters.OrderBy(x => x.Stats[(int)NextStageRoll.TestedStat]))
                {
                    bool rollResult = NextStageRoll.TryRoll(character, provisions, out int hpDamage, out int staminaDamage, out IEnumerable<string> rollLog);

                    foreach (string s in rollLog)
                    {
                        logList.Add(s);
                    }

                    bool isCharacterHealthy;

                    if (!rollResult)
                    {
                        ApplyDamageToCharacter(character, hpDamage, staminaDamage, logList, out isCharacterHealthy);

                        if (!isCharacterHealthy)
                        {
                            questFailed = true;

                            return null;
                        }

                        questFailed = false;

                        logList.Add(FailureText.Text);

                        return FailureStage;
                    }

                    ApplyDamageToCharacter(character, hpDamage, staminaDamage, logList, out isCharacterHealthy);

                    if (!isCharacterHealthy)
                    {
                        questFailed = true;

                        return null;
                    }
                }

                questFailed = false;

                logList.Add(SuccessText.Text);

                return SuccessStage;
            }

            throw new NotImplementedException();
        }
    }
}
