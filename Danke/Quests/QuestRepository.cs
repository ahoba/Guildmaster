using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Quests
{
    [Serializable]
    public class QuestRepository
    {
        public Dictionary<Guid, Quest> QuestsById { get; protected set; }

        public QuestRepository()
        {
            QuestsById = new Dictionary<Guid, Quest>();
        }
    }
}
