using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Text
{
    [Serializable]
    public class RegionText
    {
        public virtual string Id { get; set; }

        public string Text 
        { 
            get => TextProvider.Instance.GetText(Id); 
            set
            {
                if (string.IsNullOrEmpty(Id))
                {
                    Id = Guid.NewGuid().ToString();

                    TextProvider.Instance.SetText(Id, value);
                }
            }
        }
    }
}
