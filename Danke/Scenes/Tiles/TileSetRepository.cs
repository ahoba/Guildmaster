using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Scenes.Tiles
{
    [Serializable]
    public class TileSetRepository<T>
    {
        protected Dictionary<Guid, TileSet<T>> _tileSets;

        public TileSetRepository()
        {
            _tileSets = new Dictionary<Guid, TileSet<T>>();
        }
    }
}
