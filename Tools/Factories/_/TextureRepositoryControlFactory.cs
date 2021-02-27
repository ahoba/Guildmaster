using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Content;

namespace Tools.Factories
{
    public class TextureRepositoryControlFactory : IControlFactory
    {
        private TextureRepository _textureRepository;

        public TextureRepositoryControlFactory(TextureRepository textureRepository)
        {
            _textureRepository = textureRepository;
        }

        public Control CreateControl()
        {
            return new TextureRepositoryControl()
            {
                TextureRepository = _textureRepository
            };
        }
    }
}
