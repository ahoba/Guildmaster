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

        public virtual RegionText Tile { get; set; }

        public virtual RegionText Description { get; set; }

        public virtual RegionText FailureText { get; set; }

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
                QuestNotification?.Invoke(this, new QuestNotificationEventArgs(stage.StageStartText.Text));

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

                stage = stage.GetNextStage(characters, provisions, out bool questFailed, out IEnumerable<string> log);

                foreach (string s in log)
                {
                    OnQuestNotification(s);
                }

                if (questFailed)
                {
                    OnQuestNotification(TextProvider.Instance.GetText(nameof(Texts.QuestFailureCharacterFainted)));
                    OnQuestNotification(FailureText.Text);
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

    [Serializable]
    public class EndStage : QuestStage
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

    [Serializable]
    public class LinearStage : QuestStage
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

    [Serializable]
    public class BinaryStage : QuestStage
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
                        logList.Add($"{character.Name} {consumable.RegionText.Text}");

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
