using Danke.Characters;
using Danke.Items;
using Danke.Quests.QuestPrerequisites;
using Danke.Quests.QuestStages;
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
        public Guid Id { get; set; }

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

    public class QuestNotificationEventArgs : EventArgs
    {
        public string Text { get; }

        public QuestNotificationEventArgs(string text)
        {
            Text = text;
        }
    }
}
