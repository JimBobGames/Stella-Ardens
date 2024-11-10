using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Game
{
    public enum GameEventCategory
    {
        DebugEvent = 0,
        InformationEvent = 1,

    }
    public enum GameEventType
    {
        TurnUpdateEvent = 1,
        RacialUpdateEvent = 2,
        IncomeUpdateEvent = 3,
        SurveyExplorationUpdateEvent = 4,

    }

    /// <summary>
    /// An event that occurred in the game.
    /// 
    /// As there will be a LOT of these, each instance must be tiny
    /// </summary>
    public class GameEvent
    {
        public GameEventCategory GameEventCategory { get; set; }
        public GameEventType GameEventType { get; set; }
        public int Parameter1 { get; set; }
        public int Parameter2 { get; set; }
        public int Parameter3 { get; set; }
    }
}
