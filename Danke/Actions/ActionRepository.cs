using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Actions
{
    [Serializable]
    public class ActionRepository
    {
        public IList<string> Actions { get; protected set; }
    }
}
