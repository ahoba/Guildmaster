using Danke.Animations;
using Danke.Objects.Sprites;
using Danke.Scenes.Tiles;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Objects.Tiles
{
    public class TileSceneObject<T> : GameObject
    {
        public Animation<T>[] Animations { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int CurrentAnimation { get; set; }

        public int CurrentFrame { get; set; }

        public TileType[][] TileData { get; set; }
    }
}
