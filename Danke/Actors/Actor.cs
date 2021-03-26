using Danke.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Actors
{
    public abstract class Actor<T>
    {
        public Animation<T>[] Animations { get; }

        public Texture2D Texture { get; }

        public Vector2 Position { get; }
    }
}
