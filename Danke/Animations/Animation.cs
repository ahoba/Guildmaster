using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Animations
{
    [Serializable]
    public class Animation<T>
    {
        public Guid Id { get; set; }

        public virtual string Name { get; set; }

        public string SourceTextureId { get; set; }

        [JsonIgnore]
        public T SourceTexture { get; set; }

        public Rectangle[] Sprites { get; set; }
    }
}
