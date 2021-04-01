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
        public QuestStage InitialStage { get; set; }

        public virtual RegionText RegionTitle { get; set; }

        public string Title => RegionTitle.Text;

        public virtual RegionText RegionDescription { get; set; }

        public string Description => RegionDescription?.Text;

        public virtual IEnumerable<QuestPrerequisite> Prerequisites { get; set; }

        public event EventHandler<QuestNotificationEventArgs> QuestNotification;

        public bool TryGo(IEnumerable<Character> characters, IList<Item> provisions, out string text)
        {
            if (Prerequisites != null)
            {
                foreach (QuestPrerequisite prerequisite in Prerequisites)
                {
                    if (!prerequisite.CheckPrerequisites(characters, provisions, out text))
                    {
                        return false;
                    }
                }
            }

            text = string.Empty;

            QuestStage stage = InitialStage;

            while (stage != null)
            {
                QuestNotification?.Invoke(this, new QuestNotificationEventArgs(stage.Text.Text));

                if (stage.InternalRolls != null)
                {
                    foreach (Roll roll in stage.InternalRolls)
                    {
                        if (roll.RollType == RollType.SingleCharacter)
                        {
                            Character character = characters.OrderByDescending(x => x.Stats[(int)roll.TestedStat]).First();

                            roll.TryRoll(character, provisions, out int hpDamage, out int staminaDamage, out IEnumerable<string> rollLog);

                            foreach (string s in rollLog)
                            {
                                OnQuestNotification(s);
                            }

                            character.CurrentHp -= hpDamage;
                            character.CurrentStamina -= staminaDamage;

                            if (hpDamage > 0)
                            {
                                OnQuestNotification($"{hpDamage} {TextProvider.Instance.GetText(nameof(Texts.QuestHpDamage))} {character.Name}");
                            }

                            if (staminaDamage > 0)
                            {
                                OnQuestNotification($"{character.Name} {TextProvider.Instance.GetText(nameof(Texts.QuestStaminaDamage))} {hpDamage}");
                            }
                        }
                        else if (roll.RollType == RollType.WholeParty)
                        {
                            foreach (Character character in characters)
                            {
                                roll.TryRoll(character, provisions, out int hpDamage, out int staminaDamage, out IEnumerable<string> rollLog);

                                foreach (string s in rollLog)
                                {
                                    OnQuestNotification(s);
                                }

                                character.CurrentHp -= hpDamage;
                                character.CurrentStamina -= staminaDamage;

                                if (hpDamage > 0)
                                {
                                    OnQuestNotification($"{hpDamage} {TextProvider.Instance.GetText(nameof(Texts.QuestHpDamage))} {character.Name}");
                                }

                                if (staminaDamage > 0)
                                {
                                    OnQuestNotification($"{character.Name} {TextProvider.Instance.GetText(nameof(Texts.QuestStaminaDamage))} {hpDamage}");
                                }
                            }
                        }
                    }
                }

                stage = stage.GetNextStage(characters, provisions, out IEnumerable<string> log);

                foreach (string s in log)
                {
                    OnQuestNotification(s);
                }

                Character weakling = characters.FirstOrDefault(x => x.CurrentHp <= 0 || x.CurrentStamina <= 0);

                if (weakling?.CurrentHp <= 0)
                {
                    OnQuestNotification($"{weakling.Name} {TextProvider.Instance.GetText(nameof(Texts.QuestCharacterKOd))}");

                    return false;
                }

                if (weakling?.CurrentStamina <= 0)
                {
                    OnQuestNotification($"{weakling.Name} {TextProvider.Instance.GetText(nameof(Texts.QuestCharacterExhausted))}");

                    return false;
                }
            }

            return true;
        }

        protected void OnQuestNotification(string text)
        {
            QuestNotification?.Invoke(this, new QuestNotificationEventArgs(text));
        }
    }

    public abstract class QuestPrerequisite
    {
        public RegionText RegionRejectionText { get; set; }

        public string RejectionText => RegionRejectionText.Text;

        public abstract bool CheckPrerequisites(IEnumerable<Character> characters, IList<Item> provisions, out string text);
    }

    public class Reward
    {

    }

    [Serializable]
    public class Consumable
    {
        public virtual RegionText RegionText { get; set; }

        public string Text { get => RegionText.Text; }

        public virtual Guid ItemId { get; set; }

        public virtual int? Modifier { get; set; }
    }

    public enum RollType
    {
        SingleCharacter,
        WholeParty
    }

    public class QuestNotificationEventArgs : EventArgs
    {
        public string Text { get; }

        public QuestNotificationEventArgs(string text)
        {
            Text = text;
        }
    }

    [Serializable]
    public abstract class QuestStage
    {
        public RegionText Text { get; set; }

        public virtual IEnumerable<Roll> InternalRolls { get; set; }

        public virtual Roll NextStageRoll { get; set; }

        public abstract QuestStage GetNextStage(IEnumerable<Character> characters, IList<Item> provisions, out IEnumerable<string> log);
    }

    [Serializable]
    public class EndStage : QuestStage
    {
        public override QuestStage GetNextStage(IEnumerable<Character> characters, IList<Item> provisions, out IEnumerable<string> log)
        {
            log = new string[]
            {

            };

            return null;
        }
    }

    [Serializable]
    public class LinearStage : QuestStage
    {
        public virtual QuestStage NextStage { get; set; }

        public override QuestStage GetNextStage(IEnumerable<Character> characters, IList<Item> provisions, out IEnumerable<string> log)
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
                }
            }

            return NextStage;
        }
    }

    [Serializable]
    public class BinaryStage : QuestStage
    {
        public virtual QuestStage SuccessStage { get; set; }

        public virtual QuestStage FailureStage { get; set; }

        public override QuestStage GetNextStage(IEnumerable<Character> characters, IList<Item> provisions, out IEnumerable<string> log)
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

                    if (rollResult)
                    {
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

                        return SuccessStage;
                    }

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
                }

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

                    if (!rollResult)
                    {
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

                        return FailureStage;
                    }

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
                }

                return SuccessStage;
            }

            throw new NotImplementedException();
        }
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

        public IEnumerable<Reward> Rewards { get; set; }
    
        public bool TryRoll(
            Character character,
            IList<Item> provisions,
            out int hpDamage,
            out int staminaDamage,
            out IEnumerable<string> log)
        {
            IList<string> logList = new List<string>() { $"{character.Name} {TextBeforeRoll.Text}" };

            log = logList;

            int modifier = 0;

            Item toRemove = null;

            if (Consumables != null && Consumables.Count() > 0)
            {
                foreach (Item provision in provisions)
                {
                    Consumable consumable = Consumables.FirstOrDefault(x => x.ItemId == provision.Id);

                    if (consumable != null)
                    {
                        logList.Add(consumable.RegionText.Text);

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

            hpDamage = Math.Max(0, BaseHpDamage * (Threshold - modifier - roll) / Threshold);

            staminaDamage = Math.Max(0, BaseStaminaDamage * (Threshold - modifier - roll) / Threshold);

            bool success = (roll + modifier) >= Threshold;

            logList.Add(success ? $"{character.Name} {TextOnSuccess.Text}" : $"{character.Name} {TextOnFailure.Text}");

            return success;
        }
    }
}
