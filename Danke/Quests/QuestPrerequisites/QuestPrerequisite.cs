using Danke.Characters;
using Danke.Items;
using Danke.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Quests.QuestPrerequisites
{
    [Serializable]
    public abstract class QuestPrerequisite
    {
        public RegionText RegionRejectionText { get; set; }

        public string RejectionText => RegionRejectionText.Text;

        public abstract bool CheckPrerequisites(IEnumerable<Character> characters, IList<Item> provisions, out string text);
    }
}
