using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Quests;

namespace Tools.Factories
{
    public class QuestControlFactory : IControlFactory
    {
        public QuestControlFactory()
        {

        }

        public Control CreateControl()
        {
            return new QuestControl();
        }
    }
}
