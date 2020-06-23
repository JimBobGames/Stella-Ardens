using System;
using System.Collections.Generic;
using StellaArdens.Core.Data;
using StellaArdens.Core.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StellaArdens.Test
{
    [TestClass]
    public class GameDataTest
    {
        [TestMethod]
        public void TestGameCreation()
        {
            // simple empty game
            Assert.IsNotNull(new StellaArdensGame());

            // populated game
            Assert.IsNotNull(GameLoader.CreateGame());
        }
        [TestMethod]
        public void TestNations()
        {
            StellaArdensGame game = GameLoader.CreateGame();
            Assert.IsNotNull(game);

            // nations list ?
            Assert.IsNotNull(game.NationsListUnsorted);
            Assert.IsTrue(game.NationsListUnsorted.Count > 0);

            // test the nation list sorting
            IReadOnlyList<Nation> l = game.NationsListAlphabetical;
            for(int i=1;i<l.Count;i++)
            {
                Console.WriteLine(l[i].Name);
                Assert.IsTrue(l[i].Name.CompareTo(l[i-1].Name) > 0, l[i].Name + " is not after " + l[i-1].Name);
            }
            // test we can get a nation by id
            Assert.AreEqual<string>(game.GetNation(1).ShortName, "Terrans");

        }
    }
}
