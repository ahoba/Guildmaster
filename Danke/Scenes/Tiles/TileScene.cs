using Core.Scenes;
using Danke.Actors;
using Danke.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Scenes.Tiles
{
    public enum TileTypes
    {
        Floor,
        Block,
        Ceiling
    }

    public enum TileDirections
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Tile
    {
        public int ID { get; }

        public Texture2D Texture { get; }

        public TileTypes Type { get; set; }

        public bool[] EnabledDirections { get; } = new bool[Enum.GetValues(typeof(TileDirections)).Length];

        public Tile(int id, Texture2D texture)
        {
            ID = id;

            Texture = texture;
        }
    }

    public class TileSet
    {
        public int TileDimension { get; }

        public int Rows { get; }

        public int Columns { get; }

        public Tile[][] Tiles { get; private set; }

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

        public TileSet(int tileDimension)
        {
            TileDimension = tileDimension;

            Rows = 0;

            Columns = 0;
        }

        public TileSet(Texture2D tileSetSourceTexture, int tileDimension)
        {
            TileDimension = tileDimension;

            Rows = tileSetSourceTexture.Height / tileDimension;

            Columns = tileSetSourceTexture.Width / tileDimension;

            Tiles = new Tile[Rows][];

            Color[] sourceData = new Color[tileSetSourceTexture.Width * tileSetSourceTexture.Height];

            tileSetSourceTexture.GetData<Color>(sourceData);

            Vector2 offset = new Vector2(0, 0);

            for (int row = 0; row < Rows; row++)
            {
                Tiles[row] = new Tile[Columns];

                for (int column = 0; column < Columns; column++)
                {
                    Texture2D tileTexture = new Texture2D(tileSetSourceTexture.GraphicsDevice, tileDimension, tileDimension);

                    Color[] tileData = new Color[tileDimension * tileDimension];

                    for (int y = 0; y < tileDimension; y++)
                    {
                        for (int x = 0; x < tileDimension; x++)
                        {
                            int sourceY = ((int)offset.Y + y) * tileSetSourceTexture.Width;

                            int sourceX = ((int)offset.X + x);

                            tileData[y * tileDimension + x] = sourceData[sourceY + sourceX];
                        }
                    }

                    offset.X += tileDimension;

                    tileTexture.SetData<Color>(tileData);

                    Tiles[row][column] = new Tile(row * Columns + column, tileTexture);
                }

                offset.X = 0;

                offset.Y += tileDimension;
            }
        }
    }

    public struct TileMapLayer
    {
        public int[][] Tiles { get; set; }
    }

    public class TileMap
    {
        public string ContentLocation { get; set; }

        public int TileDimension { get => TileSet.TileDimension; }

        public TileSet TileSet { get; set; } = new TileSet(16);

        public int Height { get => Layers[0].Tiles.Length; }

        public int Width { get => Layers[0].Tiles[0].Length; }

        public TileMapLayer[] Layers { get; } = new TileMapLayer[2];

        public TileMap(int height, int width)
        {
            Layers[0] = new TileMapLayer()
            {
                Tiles = new int[height][]
            };

            Layers[1] = new TileMapLayer()
            {
                Tiles = new int[height][]
            };

            for (int i = 0; i < height; i++)
            {
                Layers[0].Tiles[i] = new int[width];
                Layers[1].Tiles[i] = new int[width];

                for (int j = 0; j < width; j++)
                {
                    Layers[0].Tiles[i][j] = -1;
                    Layers[1].Tiles[i][j] = -1;
                }
            }
        }

        public TileMap(int[][] backgroundLayer)
        {
            Layers[0] = new TileMapLayer()
            {
                Tiles = backgroundLayer
            };

            int[][] foregroundLayer = new int[Height][];

            for (int i = 0; i< backgroundLayer.Length; i++)
            {
                foregroundLayer[i] = new int[Width];

                for (int j = 0; j < Width; j++)
                {
                    foregroundLayer[i][j] = -1;
                }
            }

            Layers[1] = new TileMapLayer()
            {
                Tiles = foregroundLayer
            };
        }

        public TileMap(int[][] backgroundLayer, int[][] foregroundLayer)
        {
            Layers[0] = new TileMapLayer()
            {
                Tiles = backgroundLayer
            };

            Layers[1] = new TileMapLayer()
            {
                Tiles = foregroundLayer
            };
        }

        public Tile TileAt(int row, int column, TileMapLayers layer)
        {
            if (row >= Layers[(int)layer].Tiles.Length || column >= Layers[(int)layer].Tiles[row].Length)
            {
                return null;
            }

            int tileIndex = Layers[(int)layer].Tiles[row][column];

            if (tileIndex < 0 || tileIndex >= TileSet.Columns * TileSet.Columns)
            {
                return null;
            }

            return TileSet[tileIndex];
        }

        public int[][] GetLayerTiles(TileMapLayers layer)
        {
            return Layers[(int)layer].Tiles;
        }
    }

    public enum TileMapLayers
    {
        Background = 0,
        Foreground = 1
    }

    public class TileScene : Scene
    {
        public TileMap Map { get; set; }

        public TileScene() : base()
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Replace by camera logic (draw only what is on screen)

            Vector2 position = new Vector2(0, 0);

            for (int i = 0; i < Map.Height; i++)
            {
                position.X = 0;

                for (int j = 0; j < Map.Width; j++)
                {
                    spriteBatch.Draw(Map.TileAt(i, j, TileMapLayers.Background).Texture, position, Color.White);
                    spriteBatch.Draw(Map.TileAt(i, j, TileMapLayers.Foreground).Texture, position, Color.White);

                    position.X += Map.TileDimension;
                }

                position.Y += Map.TileDimension;
            }

            foreach (GameObject obj in Objects)
            {
                spriteBatch.Draw(obj.Texture, obj.Position, Color.White);
            }

            foreach (Actor actor in Actors)
            {
                spriteBatch.Draw(actor.Texture, actor.Position, Color.White);
            }
        }

        public override void LoadContent(ContentManager contentManager)
        {

        }

        public override void UnloadContent(ContentManager contentManager)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
