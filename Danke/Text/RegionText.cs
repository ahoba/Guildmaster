using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Text
{
    [Serializable]
    public class RegionText
    {
        public virtual string TextId { get; protected set; }

        public string Text 
        { 
            get => TextProvider.Instance.GetText(TextId); 
            set
            {
                if (string.IsNullOrEmpty(TextId))
                {
                    TextId = Guid.NewGuid().ToString();

                    TextProvider.Instance.SetText(TextId, value);
                }
            }
        }
    }
}
