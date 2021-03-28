using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Actions;
using Tools.Actors;

namespace Tools.Factories
{
    public class ActorRepositoryControlFactory : IControlFactory
    {
        private ActorRepository _actorRepository;

        private ActionRepository _actionRepository;

        public ActorRepositoryControlFactory(ActorRepository actorRepository, ActionRepository actionRepository)
        {
            _actorRepository = actorRepository;

            _actionRepository = actionRepository;
        }

        public Control CreateControl()
        {
            return new ActorRepositoryControl()
            {
                ActionRepository = _actionRepository,
                ActorRepository = _actorRepository
            };
        }
    }
}
