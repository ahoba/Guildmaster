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
        public BindingList<string> TextureIds { get; } = new BindingList<string>();

        public TextureRepository() : base()
        {

        }

        public void AddTexture(string textureId, Image texture)
        {
            Textures[textureId] = texture;

            TextureIds.Add(textureId);
        }

        public void RemoveTexture(string textureId)
        {
            if (base.Textures.ContainsKey(textureId))
            {
                base.Textures.Remove(textureId);

                Textures.Remove(textureId);
            }
        }

        public void FromDeserialized(TextureRepository deserialized)
        {
            Textures.Clear();

            TextureIds.Clear();

            foreach (var kv in deserialized.Textures)
            {
                AddTexture(kv.Key, kv.Value);
            }
        }
    }
}
