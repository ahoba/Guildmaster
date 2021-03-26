using System;
using System.Collections.Generic;
using System.Text;
using Danke.Actors;
using Danke.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Core.Scenes
{
    public abstract class Scene
    {
        public abstract void LoadContent(ContentManager contentManager);

        public abstract void UnloadContent(ContentManager contentManager);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
