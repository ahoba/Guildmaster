using Danke.Characters;
using Danke.Items;
using Danke.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Quests.QuestStages
{
    [Serializable]
    public abstract class QuestStage
    {
        public RegionText StageStartText { get; set; }

        public virtual IEnumerable<Roll> InternalRolls { get; set; }

        public virtual Roll NextStageRoll { get; set; }

        public abstract QuestStage GetNextStage(IEnumerable<Character> characters, IList<Item> provisions, out bool questFailed, out IEnumerable<string> log);

        protected void ApplyDamageToCharacter(Character character, int hpDamage, int staminaDamage, IList<string> logList, out bool isCharacterHealthy)
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
    }
}
