using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Core.Scenes
{
    public class SceneManager
    {
        private ContentManager ContentManager { get; set; }

        private Scene _currentScene;

        public Scene CurrentScene 
        {
            get => _currentScene;
            set
            {
                if (_currentScene != null)
                {
                    _currentScene.UnloadContent(ContentManager);
                }

                _currentScene = value;

                _currentScene.LoadContent(ContentManager);
            }
        }

        public SceneManager(ContentManager contentManager)
        {
            ContentManager = contentManager;
        }
    }
}
