using StellaArdens.Data.Game;
using StellaArdens.Data.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Engine
{
    public class TurnResolutionEngine
    {
        public void RunTurn(IStellaArdensGame? game)
        {
            if(game==null)
            {
                return;
            }
            game.TurnNumber++;

        }

        public RaceReport GenerateReportForRace(int raceId, IStellaArdensGame game)
        {
            RaceReport r = new RaceReport() { Name = "Unknown" };
            r.TurnNumber = game.TurnNumber;

            return r;
        }
    }
}
