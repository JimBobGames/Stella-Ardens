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
            ReferenceDataLoader.LoadReferenceData(game);
            CreateMap(game, 10);
            CreateNations(game);
            CreateDesigns(game);
            CreatePlayer(game);
            CreateFleetsAndTaskForces(game);

            return game;
        }

        private static void CreateFleetsAndTaskForces(StellaArdensGame game)
        {
            Nation terrans = game.GetNation(1);
            Starbase terranShipyard = (Starbase) game.GalacticMap.GetSolarSystemObject(GameStandardIds.SOL_TERRANSHIPYARDID);

            Fleet f1 = game.AddFleet(new Fleet() { FleetId = 1, Name = "Beta Fleet", Nation = terrans, HomeBase = terranShipyard });
            Fleet f2 = game.AddFleet(new Fleet() { FleetId = 2, Name = "Attack Fleet", Nation = terrans, HomeBase = terranShipyard });
            Fleet f3 = game.AddFleet(new Fleet() { FleetId = 3, Name = "Zeta Fleet", Nation = terrans, HomeBase = terranShipyard });

            TaskForce tf1 = game.AddTaskForce( new TaskForce() {TaskForceId = 11, Name = "Task Foce Victor", Fleet = f1 });
            TaskForce tf2 = game.AddTaskForce(new TaskForce() { TaskForceId = 12, Name = "Task Foce Able", Fleet = f1 });
            TaskForce tf3 = game.AddTaskForce(new TaskForce() { TaskForceId = 13, Name = "Task Foce Charle", Fleet = f1 });
            TaskForce tf4 = game.AddTaskForce(new TaskForce() { TaskForceId = 14, Name = "Task Foce Boxer", Fleet = f2 });
            TaskForce tf5 = game.AddTaskForce(new TaskForce() { TaskForceId = 15, Name = "Task Foce Zebra", Fleet = f3 });

        }

        private static void CreatePlayer(StellaArdensGame game)
        {
            game.Player = new Player()
            {
                Name = "Test Player",
                Nation = game.GetNation(1)
            };
        }

        private static void CreateMap(StellaArdensGame game, int size)
        {
            game.GalacticMap = new GalacticMap(size);

            // create solar systems
            SolarSystem solSystem = new SolarSystem() { SolarSystemId= GameStandardIds.SOL_SOLARSYSTEMID, Name = "Sol", Location = new Point() {X=5,Y=5 } };
            game.AddSolarSystem(solSystem);

            // create bodies
            Planet earth = (Planet) game.AddSolarSystemObject(new Planet() { SolarSystemObjectId = GameStandardIds.SOL_EARTHID, Name = "Earth", SolarSystem = solSystem });
            Planet mars = (Planet)game.AddSolarSystemObject(new Planet() { SolarSystemObjectId = GameStandardIds.SOL_MARSID, Name = "Mars", SolarSystem = solSystem });

            Starbase terranShipyard = (Starbase) game.AddSolarSystemObject(new Starbase() { SolarSystemObjectId = GameStandardIds.SOL_TERRANSHIPYARDID, Name = "Terran Shipyard", SolarSystem = solSystem });

        }

        private static void CreateNations(StellaArdensGame game)
        {
            Nation terrans = game.AddNation(new Nation() { Id = 1, Name = "Terran Empire", ShortName = "Terrans", StratgicPriorities = null });
            game.AddNation(new Nation() { Id = 2, Name = "Orion Khanate", ShortName = "Orions", StratgicPriorities = null });
            game.AddNation(new Nation() { Id = 3, Name = "Rigellian Confederation", ShortName = "Rigellians", StratgicPriorities = null });

            // add known systems
            SolarSystem solSystem = game.GetSolarSystem(GameStandardIds.SOL_SOLARSYSTEMID);
            terrans.KnownSolarSystems.Add(solSystem);
        }


        private static void CreateDesigns(StellaArdensGame game)
        {
            //g.CreateDesign(TERRAN_DESTROYER_DESIGNID, "Terran Destroyer", 4);
            //g.CreateDesign(ORION_DESTROYER_DESIGNID, "Orion Destroyer", 4);
        }
    }
}
