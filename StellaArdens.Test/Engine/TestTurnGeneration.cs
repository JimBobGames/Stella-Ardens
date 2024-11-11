using StellaArdens.Data.Engine;
using StellaArdens.Data.Game;
using StellaArdens.Data.Objects;
using StellaArdens.Data.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Test.Engine
{

    [TestClass]
    public class TestTurnGeneration
    {
        [TestMethod]
        public void TestSimpleTurnGeneration()
        {
            StandaloneStellaArdensGame game = TestGameCreator.CreateTestGame();
            Race r = game.GetRace(1);  

            TurnResolutionEngine tre = new TurnResolutionEngine(game);
            tre.RunTurnForRace(r, game);
                
                
            RaceReport r1 = tre.GenerateReportForRace(1, game);
            Assert.IsNotNull(r1);
            r1.Display();
        }
    }
}