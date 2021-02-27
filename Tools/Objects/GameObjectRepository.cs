using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Objects
{
    public class GameObjectRepository : Danke.Objects.GameObjectRepository
    {
        public BindingList<TileObject> Objects { get; } = new BindingList<TileObject>();

        public void AddObject(TileObject obj)
        {
            Objects.Add(obj);

            _objects[obj.Id] = obj;
        }
    }
}
