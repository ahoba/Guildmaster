using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Actors
{
    [Serializable]
    public class ActorRepository : Danke.Actors.ActorRepository<Image>
    {
        [JsonIgnore]
        public BindingList<Actor> Actors { get; } = new BindingList<Actor>();

        public void AddActor(Actor actor)
        {
            ActorsById[actor.Id] = actor;

            Actors.Add(actor);
        }
    }
}
