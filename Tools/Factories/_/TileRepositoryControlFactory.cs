using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Content;
using Tools.Scenes.Tiles;

namespace Tools.Factories
{
    public class TileRepositoryControlFactory : AbstractControlFactory<ControlFactoryArgs>
    {
        private TileSetRepository _tileSetRepository;

        private TextureRepository _textureRepository;

        public TileRepositoryControlFactory(TileSetRepository tileSetRepository, TextureRepository textureRepository)
        {
            _tileSetRepository = tileSetRepository;

            _textureRepository = textureRepository;
        }

        public override Control CreateControl(ControlFactoryArgs args)
        {
            return new TileRepositoryControl
            {
                TileSetRepository = _tileSetRepository,
                TextureRepository = _textureRepository
            };
        }
    }
}
