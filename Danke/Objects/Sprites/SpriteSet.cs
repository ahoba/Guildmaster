using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Objects.Sprites
{
    public class SpriteSet<T>
    {
        public T SourceTexture { get; }

        public int TileDimension { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public Rectangle[] Sprites { get; }

        public SpriteSet(T texture)
        {
            SourceTexture = texture;
        }
    }
}
