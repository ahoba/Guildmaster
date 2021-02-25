using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Factories
{
    public abstract class AbstractControlFactory<T> where T : ControlFactoryArgs
    {
        public abstract Control CreateControl(T args);
    }

    public class ControlFactoryArgs
    {

    }
}
