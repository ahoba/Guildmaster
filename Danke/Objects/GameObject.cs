using Danke.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Objects
{
    [Serializable]
    public abstract class GameObject
    {
        public Guid Id { get; set; }

        public virtual string Name { get; set; }

        [JsonIgnore]
        public virtual Animation<Texture2D> Animation { get; set; }
    }
}