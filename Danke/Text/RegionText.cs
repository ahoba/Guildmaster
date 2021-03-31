using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Text
{
    [Serializable]
    public class RegionText
    {
        public Guid TextId { get; protected set; }

        public string Text { get => TextProvider.Instance.GetText(TextId); }
    }
}
