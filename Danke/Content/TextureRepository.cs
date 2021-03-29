using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Content
{
    [Serializable]
    public class TextureRepository<T>
    {
        public Dictionary<string, T> Textures { get; protected set; }

        public TextureRepository()
        {
            Textures = new Dictionary<string, T>();
        }

        public bool TryGetTexture(string textureId, out T texture)
        {
            if (Textures.ContainsKey(textureId))
            {
                texture = Textures[textureId];

                return true;
            }

            texture = default(T);

            return false;
        }
    }
}
