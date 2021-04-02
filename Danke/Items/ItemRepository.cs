using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Items
{
    [Serializable]
    public class ItemRepository<T> where T : Item
    {
        public Dictionary<Guid, T> ItemsById { get; set; }

        public ItemRepository()
        {
            ItemsById = new Dictionary<Guid, T>();
        }
    }
}
