using Core.Scenes;
using Danke.Scenes.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SampleGame
{
    public class SampleGame : Game
    {
        private GraphicsDeviceManager _graphics;
        
        private SpriteBatch _spriteBatch;

        private SceneManager _sceneManager;

        public SampleGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _sceneManager = new SceneManager(Content);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            TileScene scene = new TileScene("tileset", 16);

            _sceneManager.CurrentScene = scene;

            scene.Tiles = new int[scene.TileSet.Tiles.Length][];

            int i = 0;

            int t = 0;

            foreach (Tile[] tiles in scene.TileSet.Tiles)
            {
                scene.Tiles[i] = new int[tiles.Length];

                int j = 0;

                foreach (Tile tile in tiles)
                {
                    scene.Tiles[i][j] = t;

                    j++;

                    t++;
                }

                i++;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (_sceneManager.CurrentScene != null)
            {
                _sceneManager.CurrentScene.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (_sceneManager.CurrentScene != null)
            {
                _spriteBatch.Begin();

                _sceneManager.CurrentScene.Draw(gameTime, _spriteBatch);

                _spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
