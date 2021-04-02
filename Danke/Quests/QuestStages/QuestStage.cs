using Danke.Characters;
using Danke.Items;
using Danke.Quests.Rewards;
using Danke.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Danke.Quests.QuestStages
{
    [Serializable]
    public abstract class QuestStage
    {
        public RegionText StageStartText { get; set; }

        public virtual IEnumerable<Test> Tests { get; set; }

        public virtual Roll NextStageRoll { get; set; }

        public QuestStage GetNextStage(IEnumerable<Character> characters, IList<Item> provisions, out bool questFailed, out IEnumerable<string> log)
        {
            IList<string> logList = new List<string>();

            log = logList;

            PerformTests(characters, provisions, logList, out questFailed);

            if (!questFailed)
            {
                questFailed = false;
                
                return InternalGetNextStage(characters, provisions, logList, out questFailed);
            }

            questFailed = true;

            return null;
        }

        protected virtual void PerformTests(IEnumerable<Character> characters, IList<Item> provisions, IList<string> logList, out bool questFailed)
        {
            questFailed = false;

            if (Tests != null)
            {
                foreach (Test test in Tests)
                {
                    if (test.Roll.RollType == RollType.SingleCharacter)
                    {
                        Character character = characters.OrderByDescending(x => x.Stats[(int)test.Roll.TestedStat]).First();

                        test.Roll.TryRoll(character, provisions, out int hpDamage, out int staminaDamage, out IEnumerable<string> rollLog);

                        foreach (string s in rollLog)
                        {
                            logList.Add(s);
                        }

                        ApplyDamageToCharacter(character, hpDamage, staminaDamage, logList, out bool isCharacterHealthy);

                        if (!isCharacterHealthy)
                        {
                            questFailed = true;
                        }
                    }
                    else if (test.Roll.RollType == RollType.WholeParty)
                    {
                        foreach (Character character in characters)
                        {
                            test.Roll.TryRoll(character, provisions, out int hpDamage, out int staminaDamage, out IEnumerable<string> rollLog);

                            foreach (string s in rollLog)
                            {
                                logList.Add(s);
                            }

                            ApplyDamageToCharacter(character, hpDamage, staminaDamage, logList, out bool isCharacterHealthy);

                            if (!isCharacterHealthy)
                            {
                                questFailed = true;
                            }
                        }
                    }
                }
            }
        }

        protected virtual void ApplyDamageToCharacter(Character character, int hpDamage, int staminaDamage, IList<string> logList, out bool isCharacterHealthy)
        {
            isCharacterHealthy = true;

            character.CurrentHp -= hpDamage;
            character.CurrentStamina -= staminaDamage;

            if (hpDamage > 0)
            {
                logList.Add($"{hpDamage} {TextProvider.Instance.GetText(nameof(Texts.QuestHpDamage))} {character.Name}");
            }

            if (staminaDamage > 0)
            {
                logList.Add($"{character.Name} {TextProvider.Instance.GetText(nameof(Texts.QuestStaminaDamage))} {hpDamage}");
            }

            bool kod = character.CurrentHp <= 0;

            bool exhausted = character.CurrentStamina <= 0;

            if (kod && exhausted)
            {
                isCharacterHealthy = false;

                logList.Add($"{character.Name} {TextProvider.Instance.GetText(nameof(Texts.QuestCharacterOverwhelmed))}");
            }
            else if (kod)
            {
                isCharacterHealthy = false;

                logList.Add($"{character.Name} {TextProvider.Instance.GetText(nameof(Texts.QuestCharacterKOd))}");
            }
            else if (exhausted)
            {
                isCharacterHealthy = false;

                logList.Add($"{character.Name} {TextProvider.Instance.GetText(nameof(Texts.QuestCharacterExhausted))}");
            }
        }

        protected abstract QuestStage InternalGetNextStage(IEnumerable<Character> characters, IList<Item> provisions, IList<string> logList, out bool questFailed);
    }

    [Serializable]
    public class Test
    {
        public Roll Roll { get; set; }

        public IEnumerable<Reward> Rewards { get; set; }
    }
}
