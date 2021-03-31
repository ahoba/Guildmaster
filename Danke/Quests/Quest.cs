using Danke.Characters;
using Danke.Items;
using Danke.RandomGeneration;
using Danke.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Danke.Quests
{
    [Serializable]
    public class Quest
    {
        public QuestStage Start { get; }

        public virtual RegionText RegionTitle { get; protected set; }

        public string Title => RegionTitle?.Text;

        public virtual RegionText RegionDescription { get; protected set; }

        public string Description => RegionDescription?.Text;

        public virtual IEnumerable<QuestPrerequisite> Prerequisites { get; protected set; }

        public bool TryGo(IEnumerable<Character> characters, IList<Item> provisions, out string text)
        {
            foreach (QuestPrerequisite prerequisite in Prerequisites)
            {
                if (!prerequisite.CheckPrerequisites(characters, provisions, out text))
                {
                    return false;
                }
            }

            text = string.Empty;

            return false;
        }
    }

    public abstract class QuestPrerequisite
    {
        public RegionText RegionRejectionText { get; protected set; }

        public string RejectionText => RegionRejectionText.Text;

        public abstract bool CheckPrerequisites(IEnumerable<Character> characters, IList<Item> provisions, out string text);
    }

    public class Reward
    {

    }

    [Serializable]
    public class Consumable
    {
        public virtual Guid ItemId { get; protected set; }

        public virtual int? Modifier { get; protected set; }
    }

    public enum RollType
    {
        SingleCharacter,
        WholeParty
    }



    [Serializable]
    public abstract class QuestStage
    {

        public virtual Roll Roll { get; protected set; }

        public abstract QuestStage GetNextStage(IEnumerable<Character> characters, IList<Item> provisions);
    }

    [Serializable]
    public class LinearStage : QuestStage
    {
        public virtual QuestStage NextStage { get; protected set; }

        public override QuestStage GetNextStage(IEnumerable<Character> characters, IList<Item> provisions)
        {
            if (Roll.RollType == RollType.SingleCharacter)
            {
                Character character = characters.OrderByDescending(x => x.Stats[(int)Roll.TestedStat]).First();

                Roll.TryRoll(character, provisions, out int hpDamage, out int staminaDamage);

                character.CurrentHp -= hpDamage;
                character.CurrentStamina -= staminaDamage;
            }
            else if (Roll.RollType == RollType.WholeParty)
            {
                foreach (Character character in characters)
                {
                    Roll.TryRoll(character, provisions, out int hpDamage, out int staminaDamage);

                    character.CurrentHp -= hpDamage;
                    character.CurrentStamina -= staminaDamage;
                }
            }

            return NextStage;
        }
    }

    [Serializable]
    public class BinaryStage : QuestStage
    {
        public virtual QuestStage SuccessStage { get; protected set; }

        public virtual QuestStage FailureStage { get; protected set; }

        public override QuestStage GetNextStage(IEnumerable<Character> characters, IList<Item> provisions)
        {
            if (Roll.RollType == RollType.SingleCharacter)
            {
                foreach (Character character in characters.OrderByDescending(x => x.Stats[(int)Roll.TestedStat]))
                {
                    if (Roll.TryRoll(character, provisions, out int hpDamage, out int staminaDamage))
                    {
                        character.CurrentHp -= hpDamage;
                        character.CurrentStamina -= staminaDamage;

                        return SuccessStage;
                    }

                    character.CurrentHp -= hpDamage;
                    character.CurrentStamina -= staminaDamage;
                }

                return FailureStage;
            }
            else if (Roll.RollType == RollType.WholeParty)
            {
                foreach (Character character in characters.OrderBy(x => x.Stats[(int)Roll.TestedStat]))
                {
                    if (!Roll.TryRoll(character, provisions, out int hpDamage, out int staminaDamage))
                    {
                        character.CurrentHp -= hpDamage;
                        character.CurrentStamina -= staminaDamage;

                        return FailureStage;
                    }

                    character.CurrentHp -= hpDamage;
                    character.CurrentStamina -= staminaDamage;
                }

                return SuccessStage;
            }

            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class Roll
    {
        public virtual Stats TestedStat { get; protected set; }
        
        public virtual RollType RollType { get; protected set; }

        public virtual int Threshold { get; protected set; } = 20;

        public int BaseHpDamage { get; set; }

        public int BaseStaminaDamage { get; set; }

        public IEnumerable<Consumable> Consumables { get; set; }

        public IEnumerable<Reward> Rewards { get; set; }
    
        public bool TryRoll(
            Character character, 
            IList<Item> provisions,
            out int hpDamage,
            out int staminaDamage)
        {
            int modifier = 0;

            Item toRemove = null;

            foreach (Item provision in provisions)
            {
                Consumable consumable = Consumables.FirstOrDefault(x => x.ItemId == provision.Id);

                if (consumable != null)
                {
                    toRemove = provision;

                    if (consumable.Modifier.HasValue)
                    {
                        modifier = consumable.Modifier.Value;

                        break;
                    }
                    else
                    {
                        hpDamage = 0;

                        staminaDamage = 0;

                        return true;
                    }
                }
            }

            if (toRemove != null)
            {
                provisions.Remove(toRemove);
            }

            modifier += character.Stats[(int)TestedStat] / 3;

            // TO DO: Check character's skills

            int roll = RandomGenerator.GetRandom(1, 20);

            if (roll == 1)
            {
                // TO DO: Critical rolls
            }
            else if (roll == 20)
            {
                // TO DO: Critical rolls
            }

            hpDamage = Math.Max(0, BaseHpDamage * (Threshold - modifier) / Threshold);

            staminaDamage = Math.Max(0, BaseStaminaDamage * (Threshold - modifier) / Threshold);

            return true;
        }
    }
}
