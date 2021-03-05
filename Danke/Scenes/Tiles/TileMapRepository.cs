using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Scenes.Tiles
{
    [Serializable]
    public class TileMapRepository<T>
    {
        protected Dictionary<Guid, TileMap<T>> _maps;

        public TileMapRepository()
        {
            _maps = new Dictionary<Guid, TileMap<T>>();
        }
    }
}
