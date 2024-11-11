using StellaArdens.Data.Game;
using StellaArdens.Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Engine
{
    internal class SurveyAndExplorationEngine : AbstractEngine
    {
        internal static void ResolveSurveyAndExplorationSpending(Race r, StratgicPriorities sp)
        {
            // record the priorities
            r.RaceSurveyData.Priority = sp.Value;
        }
    }
}
