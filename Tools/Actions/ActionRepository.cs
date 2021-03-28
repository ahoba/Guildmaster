using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Actions
{
    [Serializable]
    public class ActionRepository : Danke.Actions.ActionRepository
    {
        public ActionRepository()
        {
            Actions = new BindingList<string>();

            foreach (string s in Danke.Constants.DefaultActions)
            {
                Actions.Add(s);
            }
        }
    }
}
