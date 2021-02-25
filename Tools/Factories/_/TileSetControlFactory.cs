using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Scenes.Tiles;

namespace Tools.Factories
{
    public class TileSetControlFactory : AbstractControlFactory<ControlFactoryArgs>
    {
        private TileSetRepository _tileSetRepository;

        public TileSetControlFactory(TileSetRepository tileSetRepository)
        {
            _tileSetRepository = tileSetRepository;
        }

        public override Control CreateControl(ControlFactoryArgs args)
        {
            return new TileSetControl()
            {
                TileSetRepository = _tileSetRepository
            };
        }
    }
}
