﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Content
{
    public class TextureRepository<T>
    {
        protected Dictionary<string, T> _textures;

        public TextureRepository()
        {
            _textures = new Dictionary<string, T>();
        }

        public bool TryGetTexture(string textureId, out T texture)
        {
            if (_textures.ContainsKey(textureId))
            {
                texture = _textures[textureId];

                return true;
            }

            texture = default(T);

            return false;
        }
    }
}