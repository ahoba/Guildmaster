using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Scenes.Tiles
{
    [Serializable]
    public class TileSetRepository<T>
    {
        public Dictionary<Guid, TileSet<T>> TileSetsById { get; protected set; }

        public TileSetRepository()
        {
            TileSetsById = new Dictionary<Guid, TileSet<T>>();
        }
    }
}
