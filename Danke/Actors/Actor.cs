using Danke.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Actors
{
    [Serializable]
    public abstract class Actor<T>
    {
        public Guid Id { get; set; }

        public virtual string Name { get; set; }

        public Dictionary<string, Animation<T>> Animations { get; } = new Dictionary<string, Animation<T>>();

        public Texture2D Texture { get; }

        public Vector2 Position { get; }
    }
}