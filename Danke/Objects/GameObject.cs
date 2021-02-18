using Danke.Objects.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Objects
{
    public abstract class GameObject
    {
        public Vector2 Position { get; set; }

        public abstract Texture2D Sprite { get; }
    }
}
