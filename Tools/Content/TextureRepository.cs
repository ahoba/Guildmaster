using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Content
{
    public class TextureRepository : Danke.Content.TextureRepository<Image>
    {
        public IEnumerable<string> TextureIds => _textures.Keys;

        public BindingList<string> Textures { get; } = new BindingList<string>();

        public TextureRepository() : base()
        {

        }

        public void AddTexture(string textureId, Image texture)
        {
            _textures[textureId] = texture;

            Textures.Add(textureId);
        }

        public void RemoveTexture(string textureId)
        {
            if (_textures.ContainsKey(textureId))
            {
                _textures.Remove(textureId);

                Textures.Remove(textureId);
            }
        }
    }
}
