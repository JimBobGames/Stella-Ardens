using System;
using StellaArdens.Core.Data;
using StellaArdens.Core.Engines;
using StellaArdens.Core.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StellaArdens.Test
{
    [TestClass]
    public class TurnResolutionTest
    {
        [TestMethod]
        public void TestSingleTurnResolution()
        {
            StellaArdensGame game = GameLoader.CreateGame();
            TurnResolutionEngine turnEngine = new TurnResolutionEngine
            {
                Game = game
            };

            // run one turn 
            turnEngine.ResolveTurn();

            game.GameEventLog.DisplayEvents(game);
        }
    }
}
