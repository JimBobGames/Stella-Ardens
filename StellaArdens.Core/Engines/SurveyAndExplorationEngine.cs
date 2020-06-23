using StellaArdens.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellaArdens.Core.Engines
{
    /// <summary>
    /// Class which handles the mechanics ofsurvey and exploration
    /// </summary>
    public class SurveyAndExplorationEngine : AbstractEngine
    {

        public int GetSurveyPoints(Ship s)
        {
            if (s == null)
            {
                return 0;
            }
            Design d = Game.GetDesign(s.DesignId);

            // modified by crew quality perhaps ?
            return d.SurveySpeed;
        }

        public void ResolveSurveyAndExplorationSpending(Nation n, StratgicPriorities sp)
        {
            // how much money ?
            int moneyAvailable = 1000;

            // resolving survey for race
            Game.GameEventLog.AddEvent(Game.TurnNumber, GameEventCategory.InformationEvent, GameEventType.SurveyExplorationUpdateEvent, n.Id, sp.Value, moneyAvailable);

        }
    }
}
