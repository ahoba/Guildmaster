using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Actors
{
    [Serializable]
    public class ActorRepository<T>
    {
        protected Dictionary<Guid, Actor<T>> _actors;

        public ActorRepository()
        {
            _actors = new Dictionary<Guid, Actor<T>>();
        }
    }
}
