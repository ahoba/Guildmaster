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
    public enum RollType
    {
        SingleCharacter,
        WholeParty
    }

    [Serializable]
    public class Consumable
    {
        public virtual RegionText Text { get; set; }

        public virtual Guid ItemId { get; set; }

        public virtual int? Modifier { get; set; }
    }

    [Serializable]
    public class Roll
    {
        public RegionText TextBeforeRoll { get; set; }

        public RegionText TextOnSuccess { get; set; }

        public RegionText TextOnFailure { get; set; }

        public virtual Stats TestedStat { get; set; }

        public virtual RollType RollType { get; set; }

        public virtual int Threshold { get; set; } = 20;

        public int BaseHpDamage { get; set; }

        public int BaseStaminaDamage { get; set; }

        public IEnumerable<Consumable> Consumables { get; set; }

        public bool TryRoll(
            Character character,
            IList<Item> provisions,
            out int hpDamage,
            out int staminaDamage,
            out IEnumerable<string> log)
        {
            IList<string> logList = new List<string>();

            log = logList;

            int modifier = 0;

            Item toRemove = null;

            bool passed = false;

            if (Consumables != null && Consumables.Count() > 0)
            {
                foreach (Item provision in provisions)
                {
                    Consumable consumable = Consumables.FirstOrDefault(x => x.ItemId == provision.Id);

                    if (consumable != null)
                    {
                        logList.Add($"{character.Name} {consumable.Text.Text}");

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

                            passed = true;

                            break;
                        }
                    }
                }
            }

            if (toRemove != null)
            {
                provisions.Remove(toRemove);

                if (passed)
                {
                    hpDamage = 0;

                    staminaDamage = 0;

                    return true;
                }
            }

            logList.Add($"{character.Name} {TextBeforeRoll.Text}");

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

            hpDamage = Math.Max(0, BaseHpDamage * (Threshold - modifier - roll) / Threshold);

            staminaDamage = Math.Max(0, BaseStaminaDamage * (Threshold - modifier - roll) / Threshold);

            bool success = (roll + modifier) >= Threshold;

            logList.Add(success ? $"{character.Name} {TextOnSuccess.Text}" : $"{character.Name} {TextOnFailure.Text}");

            return success;
        }
    }
}
