using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Danke.Scenes.Tiles
{
    public enum TileType
    {
        Floor,
        Block,
        Ceiling
    }

    public enum TileDirection
    {
        Up,
        Down,
        Left,
        Right
    }


    public class Tile
    {
        public Rectangle TextureRectangle { get; set; }

        public TileType Type { get; set; }

        public bool[] EnabledDirections { get; set; } = new bool[Enum.GetValues(typeof(TileDirection)).Length];

        public Tile()
        {

        }
    }
}
