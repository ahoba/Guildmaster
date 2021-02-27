using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Objects
{
    public class GameObjectRepository
    {
        protected Dictionary<Guid, GameObject> _objects;

        public GameObjectRepository()
        {
            _objects = new Dictionary<Guid, GameObject>();
        }
    }
}
