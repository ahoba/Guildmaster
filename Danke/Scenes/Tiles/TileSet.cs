using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Danke.Scenes.Tiles
{
    [DataContract]
    public class TileSet
    {
        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public int TileDimension { get; set; }

        public int Rows { get => Tiles == null ? 0 : Tiles.Length; }

        public int Columns { get => Tiles == null ? 0 : Tiles[0].Length; }

        [DataMember]
        public Tile[][] Tiles { get; protected set; }

        public Tile this[int tile]
        {
            get
            {
                if (tile >= Rows * Columns)
                {
                    return null;
                }

                return Tiles[tile / Columns][tile % Columns];
            }
        }

        public TileSet(string content, int tileDimension)
        {
            Content = content;

            TileDimension = tileDimension;
        }

        public TileSet(string content, Texture2D tileSetSourceTexture, int tileDimension)
        {
            Content = content;

            TileDimension = tileDimension;

            SetTexture(tileSetSourceTexture);
        }

        public void SetTexture(Texture2D tileSetSourceTexture)
        {
            int imageRows = tileSetSourceTexture.Height / TileDimension;
            int imageColumns = tileSetSourceTexture.Width / TileDimension;

            if (Tiles == null)
            {
                Tiles = new Tile[imageRows][];
            }

            Color[] sourceData = new Color[tileSetSourceTexture.Width * tileSetSourceTexture.Height];

            tileSetSourceTexture.GetData<Color>(sourceData);

            Vector2 offset = new Vector2(0, 0);

            for (int i = 0; i < Rows; i++)
            {
                if (i < imageRows)
                {
                    if (Tiles[i] == null)
                    {
                        Tiles[i] = new Tile[imageColumns];
                    }

                    for (int j = 0; j < Columns; j++)
                    {
                        if (j < imageColumns)
                        {
                            Texture2D tileTexture = Tiles[i][j] == null ?
                                new Texture2D(tileSetSourceTexture.GraphicsDevice, TileDimension, TileDimension) :
                                Tiles[i][j].Texture;

                            Color[] tileData = new Color[TileDimension * TileDimension];

                            for (int y = 0; y < TileDimension; y++)
                            {
                                for (int x = 0; x < TileDimension; x++)
                                {
                                    int sourceY = ((int)offset.Y + y) * tileSetSourceTexture.Width;

                                    int sourceX = ((int)offset.X + x);

                                    tileData[y * TileDimension + x] = sourceData[sourceY + sourceX];
                                }
                            }

                            offset.X += TileDimension;

                            tileTexture.SetData<Color>(tileData);

                            if (Tiles[i][j] == null)
                            {
                                Tiles[i][j] = new Tile(i * Columns + j, tileTexture);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    offset.X = 0;

                    offset.Y += TileDimension;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
