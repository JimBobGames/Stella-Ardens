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

            Fleet f1 = game.AddFleet(new Fleet() { FleetId = 1, Name = "Beta Fleet", Nation = terrans, HomeBase = terranShipyard, FleetAllocation = FleetAllocation.Unallocated });
            Fleet f2 = game.AddFleet(new Fleet() { FleetId = 2, Name = "Attack Fleet", Nation = terrans, HomeBase = terranShipyard, FleetAllocation = FleetAllocation.Unallocated });
            Fleet f3 = game.AddFleet(new Fleet() { FleetId = 3, Name = "Zeta Fleet", Nation = terrans, HomeBase = terranShipyard, FleetAllocation = FleetAllocation.Unallocated });
            Fleet f4 = game.AddFleet(new Fleet() { FleetId = 4, Name = "Survey Fleet", Nation = terrans, HomeBase = terranShipyard, FleetAllocation = FleetAllocation.SurveyCommand });

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
            Hull corvetteHull = game.GetHull(GameStandardIds.ID_HULL_CORVETTE);
            Hull escortHull = game.GetHull(GameStandardIds.ID_HULL_ESCORT);
            Hull destroyerHull = game.GetHull(GameStandardIds.ID_HULL_DESTROYER);
            Hull frigateHull = game.GetHull(GameStandardIds.ID_HULL_FRIGATE);
            Engine militaryEngine = game.GetEngine(GameStandardIds.ID_ENGINE_BASIC_MILITARY_SMALL);
            Shield basicShield = game.GetShield(GameStandardIds.ID_BASIC_SHIELD);
            Armour basicArmour = game.GetArmour(GameStandardIds.ID_BASIC_ARMOUR);

            game.AddDesign(CreateDesign(GameStandardIds.TERRAN_CORVETTE_DESIGNID, "Terran Corvette", corvetteHull, militaryEngine, 1));
            game.AddDesign(CreateDesign(GameStandardIds.TERRAN_ESCORT_DESIGNID, "Terran Escort", escortHull, militaryEngine, 1));
            game.AddDesign(CreateDesign(GameStandardIds.TERRAN_FRIGATE_DESIGNID, "Terran Frigate", frigateHull, militaryEngine, 1));
            game.AddDesign(CreateDesign(GameStandardIds.TERRAN_DESTROYER_DESIGNID, "Terran Destoyer", destroyerHull, militaryEngine, 1));
            //g.CreateDesign(TERRAN_DESTROYER_DESIGNID, "Terran Destroyer", 4);
            //g.CreateDesign(TERRAN_DESTROYER_DESIGNID, "Terran Destroyer", 4);
            //g.CreateDesign(ORION_DESTROYER_DESIGNID, "Orion Destroyer", 4);
        }

        private static Design CreateDesign(int id, string name, Hull h, Engine e, int numEngines)
        {
            Design d = new Design();
            d.Name = name;
            d.DesignId = id;
            d.Hull = h;
            d.Engine = e;
            d.NumberOfEngines = numEngines;


            return d;
        }
    }
}
