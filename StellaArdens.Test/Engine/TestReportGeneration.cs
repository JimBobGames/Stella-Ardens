using StellaArdens.Data.Engine;
using StellaArdens.Data.Game;
using StellaArdens.Data.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Test.Engine
{

    [TestClass]
    public class TestReportGeneration
    {
        [TestMethod]
        public void TestSimpleReportGeneration()
        {
            StandaloneStellaArdensGame game = TestGameCreator.CreateTestGame();

            TurnResolutionEngine tre = new TurnResolutionEngine();

            RaceReport r1 = tre.GenerateReportForRace(1, game);
            Assert.IsNotNull(r1);
            r1.Display();
        }
    }
}