using StellaArdens.Data.Engine;
using StellaArdens.Data.Game;
using StellaArdens.Data.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens
{
    public  class Controller
    {
        public IStellaArdensGame? Game { get; set; }
            
        public RaceReport? RaceReport { get; set; }
        public TurnResolutionEngine? TurnResolutionEngine { get; set; }

        public void RunTurn()
        {
            TurnResolutionEngine.RunTurn(Game);
            RaceReport = TurnResolutionEngine.GenerateReportForRace(Game.Player.RaceId, Game);

        }
    }
}
