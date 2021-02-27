using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Objects;

namespace Tools.Factories
{
    public class ObjectRepositoryControlFactory : AbstractControlFactory<ControlFactoryArgs>
    {
        private GameObjectRepository _objectRepository;

        public ObjectRepositoryControlFactory(GameObjectRepository objectRepository)
        {
            _objectRepository = objectRepository;
        }

        public override Control CreateControl(ControlFactoryArgs args)
        {
            return new ObjectRepositoryControl()
            {
                ObjectRepository = _objectRepository
            };
        }
    }
}
