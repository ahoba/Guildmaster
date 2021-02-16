using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Actors
{
    public abstract class Actor
    {
        public Texture2D Texture { get; }

        public Vector2 Position { get; }
    }
}
