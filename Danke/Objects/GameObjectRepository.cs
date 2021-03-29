using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Objects
{
    [Serializable]
    public class GameObjectRepository
    {
        public Dictionary<Guid, GameObject> ObjectsById { get; protected set; }

        public GameObjectRepository()
        {
            ObjectsById = new Dictionary<Guid, GameObject>();
        }
    }
}