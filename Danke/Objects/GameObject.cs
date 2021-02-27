using Danke.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Objects
{
    public abstract class GameObject
    {
        public Guid Id { get; set; }

        public virtual string Name { get; set; }

        public Vector2 Position { get; set; }

        public Animation<Texture2D> Animation { get; set; }
    }
}
