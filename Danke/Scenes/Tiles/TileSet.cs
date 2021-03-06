using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Danke.Scenes.Tiles
{
    [Serializable]
    public class TileSet<T>
    {
        public Guid Id { get; set; }

        public virtual string Name { get; set; }

        [JsonIgnore]
        public virtual T Texture { get; set; }

        public string TextureId { get; set; }

        public int TileDimension { get; set; }

        public int Rows { get => Tiles == null ? 0 : Tiles.Length; }

        public int Columns { get => Tiles == null ? 0 : Tiles[0].Length; }

        [JsonIgnore]
        public Tile[][] Tiles { get; set; }

        public Tile this[int tile]
        {
            get
            {
                if (tile < 0 || tile >= Rows * Columns)
                {
                    return null;
                }

                return Tiles[tile / Columns][tile % Columns];
            }
        }

        /// <summary>
        /// TileSet constructor
        /// </summary>
        /// <param name="tileDimension">Tile's dimension in pixels</param>
        /// <param name="textureId">Texture's Id</param>
        /// <param name="texture">Texture, either Image or Texture2D</param>
        /// <param name="rows">TileSet row count in tiles</param>
        /// <param name="columns">TileSet column count in tiles</param>
        public TileSet(int tileDimension, string textureId, T texture, int rows, int columns)
        {
            TileDimension = tileDimension;

            TextureId = textureId;

            Texture = texture;

            Tiles = new Tile[rows][];

            for (int i = 0; i < rows; i++)
            {
                Tiles[i] = new Tile[columns];

                for (int j = 0; j < columns; j++)
                {
                    Tiles[i][j] = new Tile()
                    {
                        Rectangle = new Rectangle(
                            j * tileDimension,
                            i * tileDimension,
                            tileDimension,
                            tileDimension)
                    };
                }
            }
        }
    }
}
