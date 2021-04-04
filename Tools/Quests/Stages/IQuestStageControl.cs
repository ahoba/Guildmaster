using Danke.Quests.QuestStages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Quests
{
    public interface IQuestStageControl
    {
        QuestStage QuestStage { get; }
    }
}
