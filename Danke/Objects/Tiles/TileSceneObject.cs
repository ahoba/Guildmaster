using Danke.Objects.Sprites;
using Danke.Scenes.Tiles;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Objects.Tiles
{
    public class TileSceneObject : GameObject
    {
        public SpriteSet SpriteSet { get; set; }

        public int[][] Animations { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int CurrentAnimation { get; set; }

        public int CurrentFrame { get; set; }

        public TileType[][] TileData { get; set; }

        public override Texture2D Sprite
        {
            get
            {
                if (Animations == null)
                {
                    return null;
                }

                if (CurrentAnimation < 0 || CurrentAnimation >= Animations.Length)
                {
                    return null;
                }

                if (SpriteSet == null)
                {
                    return null;
                }

                int[] animation = Animations[CurrentAnimation];

                CurrentFrame %= animation.Length;

                int spriteId = Animations[CurrentAnimation][CurrentFrame];

                return SpriteSet.Sprites[spriteId];
            }
        }
    }
}
