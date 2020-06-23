using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SACD = StellaArdens.Core.Data;
using SACP = StellaArdens.Core.Persistence;

namespace StellaArdens.Test
{
    [TestClass]
    public class SimpleTests
    {
        private SACD.StellaArdensGame game = null;

        [TestInitialize()]
        public void Initialize()
        {
            game = SACP.GameLoader.CreateGame(); //new MBCD.MariBellumGame();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            game = null;
        }

        [TestMethod]
        public void TestReferenceDataLoading()
        {
            Assert.IsNotNull(game, "Test Game is null");
            Assert.IsTrue(game.GunData.Count > 0, "No gun reference data loaded");
        }
    }
}
