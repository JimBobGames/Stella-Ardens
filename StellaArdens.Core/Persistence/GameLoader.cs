using StellaArdens.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellaArdens.Core.Persistence
{
    public class GameLoader
    {
        public static StellaArdensGame CreateGame()
        {
            StellaArdensGame game = new StellaArdensGame
            {
                TurnNumber = 0
            };
            ReferenceDataLoader.LoadGunData(game);
            CreateMap(game, 10);
            CreateNations(game);
            CreateDesigns(game);

            return game;
        }

        private static void CreateMap(StellaArdensGame game, int size)
        {
            game.GalacticMap = new GalacticMap(size);
        }

        private static void CreateNations(StellaArdensGame game)
        {
            game.AddNation(new Nation() { Id = 1, Name = "Terran Empire", ShortName = "Terrans", StratgicPriorities = null });
            game.AddNation(new Nation() { Id = 2, Name = "Orion Khanate", ShortName = "Orions", StratgicPriorities = null });
            game.AddNation(new Nation() { Id = 3, Name = "Rigellian Confederation", ShortName = "Rigellians", StratgicPriorities = null });
        }


        private static void CreateDesigns(StellaArdensGame game)
        {
            //g.CreateDesign(TERRAN_DESTROYER_DESIGNID, "Terran Destroyer", 4);
            //g.CreateDesign(ORION_DESTROYER_DESIGNID, "Orion Destroyer", 4);
        }
    }
}
