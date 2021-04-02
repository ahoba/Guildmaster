using Danke.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Items
{
    public abstract class Item
    {
        public Guid Id { get; set; }

        public RegionText Name { get; set; }

        public RegionText Description { get; set; }
    }
}
