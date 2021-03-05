using Newtonsoft.Json;
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
    [Serializable]
    public class TextureRepository : Danke.Content.TextureRepository<Image>
    {
        [JsonIgnore]
        public BindingList<string> Textures { get; } = new BindingList<string>();

        public TextureRepository() : base()
        {

        }

        [JsonConstructor]
        public TextureRepository(IEnumerable<string> textureIds)
        {
            foreach (string id in textureIds)
            {
                _textures.Add(id, null);
            }
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
