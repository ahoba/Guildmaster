using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Actors
{
    [Serializable]
    public class ActorRepository<T>
    {
        public Dictionary<Guid, Actor<T>> ActorsById { get; protected set; }

        public ActorRepository()
        {
            ActorsById = new Dictionary<Guid, Actor<T>>();
        }
    }
}
