using Danke.Animations;
using Danke.Scenes.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Objects.Tiles
{
    [Serializable]
    public class TileObject<T> : GameObject
    {
        public Animation<T>[] Animations { get; set; }

        public int TileWidth { get; set; }

        public int TileHeight { get; set; }

        public TileType[][] TileData { get; set; }
    }

    [Serializable]
    public class TileObjectInstance<T> : TileObject<T>
    {
        public int X
        {
            get => (int)Position.X;
            set
            {
                Position = new Vector2(value, Position.Y);
            }
        }

        public int Y
        {
            get => (int)Position.Y;
            set
            {
                Position = new Vector2(Position.X, value);
            }
        }

        public Vector2 Position { get; set; }
    }
}
