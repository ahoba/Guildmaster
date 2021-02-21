using Core.Scenes;
using Danke.Actors;
using Danke.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Danke.Scenes.Tiles
{
    public class TileScene : Scene
    {
        private struct TextureWrapper
        {
            public Vector2 Position { get; set; }

            public Texture2D Texture { get; set; }
        }

        private TileMap _baseMap;

        private Texture2D[][] _background;

        private List<TextureWrapper> _foreground = new List<TextureWrapper>();

        public TileScene(TileMap baseMap) : base()
        {
            _baseMap = baseMap;

            _background = new Texture2D[_baseMap.Height][];

            for(int i = 0; i < _baseMap.Height; i++)
            {
                _background[i] = new Texture2D[_baseMap.Width];

                for (int j = 0; j < _baseMap.Width; j++)
                {
                    _background[i][j] = _baseMap.TileAt(i, j, TileMapLayers.Background).Texture;

                    Tile foregroundTile = _baseMap.TileAt(i, j, TileMapLayers.Foreground);

                    if (foregroundTile != null)
                    {
                        _foreground.Add(new TextureWrapper()
                        {
                            Position = new Vector2(i, j),
                            Texture = foregroundTile.Texture
                        });
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Replace by camera logic (draw only what is on screen)

            Vector2 position = new Vector2(0, 0);

            for (int i = 0; i < _baseMap.Height; i++)
            {
                position.X = 0;

                for (int j = 0; j < _baseMap.Width; j++)
                {
                    spriteBatch.Draw(_baseMap.TileAt(i, j, TileMapLayers.Background).Texture, position, Color.White);
                    spriteBatch.Draw(_baseMap.TileAt(i, j, TileMapLayers.Foreground).Texture, position, Color.White);

                    position.X += _baseMap.TileDimension;
                }

                position.Y += _baseMap.TileDimension;
            }

            foreach (GameObject obj in Objects)
            {
                //Texture2D objectSprite = obj.Sprite;

                //if (objectSprite != null)
                //{
                //    spriteBatch.Draw(obj.Sprite, obj.Position, Color.White);
                //}
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
