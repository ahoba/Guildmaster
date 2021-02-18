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

    [DataContract]
    public class Tile
    {
        [DataMember]
        public int ID { get; set; }

        public Texture2D Texture { get; }

        [DataMember]
        public TileType Type { get; set; }

        [DataMember]
        public bool[] EnabledDirections { get; set; } = new bool[Enum.GetValues(typeof(TileDirection)).Length];

        public Tile(int id, Texture2D texture)
        {
            ID = id;

            Texture = texture;
        }
    }
}
