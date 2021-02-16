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
    public class Tile
    {
        public Texture2D Texture { get; }

        public Tile(Texture2D texture)
        {
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
                if (tile / Tiles.Length >= Tiles.Length)
                {
                    return Tiles[0][0];
                }

                return Tiles[tile / Tiles.Length][tile % Tiles[0].Length];
            }
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

                    Tiles[row][column] = new Tile(tileTexture);
                }

                offset.X = 0;

                offset.Y += tileDimension;
            }
        }
    }

    public class TileScene : Scene
    {
        public TileSet TileSet { get; private set; }

        public int[][] Tiles { get; set; }

        public int TileDimension { get; }

        private string TileContent { get; }
        
        public TileScene(string tileContent, int tileDimension) : base()
        {
            TileContent = tileContent;

            TileDimension = tileDimension;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Replace by camera logic (draw only what is on screen)

            Vector2 position = new Vector2(0, 0);

            foreach (int[] tiles in Tiles)
            {
                position.X = 0;

                foreach (int tile in tiles)
                {
                    spriteBatch.Draw(TileSet[tile].Texture, position, Color.White);
                    
                    position.X += TileDimension;
                }

                position.Y += TileDimension;
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
            Texture2D tileSetSourceTexture = contentManager.Load<Texture2D>(TileContent);

            TileSet = new TileSet(tileSetSourceTexture, TileDimension);
        }

        public override void UnloadContent(ContentManager contentManager)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
