using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Content
{
    public class TextureRepository : Danke.Content.TextureRepository<Image>
    {
        public TextureRepository() : base()
        {

        }

        public void AddTexture(string textureId, Image texture)
        {
            _textures[textureId] = texture;
        }
    }
}
