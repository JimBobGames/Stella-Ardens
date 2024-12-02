using StellaArdens.Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StellaArdens.Data.Game
{
    public class TestGameCreator
    {
        public static StandaloneStellaArdensGame CreateTestGame()
        {
            StandaloneStellaArdensGame g = new StandaloneStellaArdensGame();
            g.TurnNumber = 1;

            CreateMap(g);
            CreateRaces(g);

            CreatePlayer(g);
            /*
            ReferenceDataLoader.LoadReferenceData(g);
            CreateMap(g, 10);
            CreateRaces(g);
            */

            CreateDesigns(g);
            CreateFleetsAndTaskForces(g);
          
            return g;
        }
        private static void CreateDesigns(IStellaArdensGame game)
        {
            Design d = new Design()
            {
                Name = "Explorer",
                DesignId = GameStandardIds.TERRAN_SCOUT_DESIGNID,
                RaceId = GameStandardIds.RACEID_TERRANS,
                Maintainance = 100,
                StrategicSpeed = 4,
                TacticalSpeed = 5,
                DesignType = DesignType.Starship,
                
            };
            game.AddDesign(d);
        }

        private static void CreateFleetsAndTaskForces(IStellaArdensGame game)
        {
            Fleet f = new Fleet()
            {
                Name = "Survey Fleet 1",
                FleetId = GameStandardIds.TERRAN_SURVEYFLEET01_FLEETID,
                RaceId = GameStandardIds.RACEID_TERRANS,
                BudgetAreas = Engine.BudgetAreas.SurveyAndExploration,
            };
            game.AddFleet(f);

            // create a ship
            Unit u = new Unit() {
                Name = "Explorer 01",
                DesignId = GameStandardIds.TERRAN_SCOUT_DESIGNID,
                UnitId = game.NextId(),
            };
            f.Units.Add(u);
        }

        private static void CreatePlayer(IStellaArdensGame game)
        {
            game.Player = new Player()
            {
                Name = "Test Player",
                PlayerId = 1,
                RaceId = GameStandardIds.RACEID_TERRANS
            };
        }

        /// <summary>
        /// see https://travellermap.com/?p=-96.893!71.595!7.45&style=print
        /// </summary>
        /// <param name="game"></param>
        /// <param name="size"></param>
        private static void CreateMap(IStellaArdensGame game)
        {
            // create solar systems (Regina on the traveller map)
            SolarSystem solSystem = new SolarSystem() { SolarSystemId = GameStandardIds.SOL_SOLARSYSTEMID, Name = "Sol", Location = new Point() { X = 5, Y = 5 } };
            game.AddSolarSystem(solSystem);

            SolarSystem ruieSystem = new SolarSystem() { SolarSystemId = GameStandardIds.RUIE_SOLARSYSTEMID, Name = "Ruie", Location = new Point() { X = 4, Y = 5 } };
            game.AddSolarSystem(ruieSystem);

            SolarSystem hefrySystem = new SolarSystem() { SolarSystemId = GameStandardIds.HEFRY_SOLARSYSTEMID, Name = "Hefry", Location = new Point() { X = 4, Y = 3 } };
            game.AddSolarSystem(hefrySystem);

            SolarSystem jengheSystem = new SolarSystem() { SolarSystemId = GameStandardIds.JENGHE_SOLARSYSTEMID, Name = "Jenghe", Location = new Point() { X = 4, Y = 6 } };
            game.AddSolarSystem(jengheSystem);

            /*
            // create bodies
            Planet earth = (Planet)game.AddSolarSystemObject(new Planet() { SolarSystemObjectId = GameStandardIds.SOL_EARTHID, Name = "Earth", SolarSystem = solSystem });
            Planet mars = (Planet)game.AddSolarSystemObject(new Planet() { SolarSystemObjectId = GameStandardIds.SOL_MARSID, Name = "Mars", SolarSystem = solSystem });

            Starbase terranShipyard = (Starbase)game.AddSolarSystemObject(new Starbase() { SolarSystemObjectId = GameStandardIds.SOL_TERRANSHIPYARDID, Name = "Terran Shipyard", SolarSystem = solSystem });

            // create other systems
            SolarSystem acSystem = CreateSolarSystem(game, "Alpha Centaurii", 100, new Point() { X = 5, Y = 5 });


            // create warplines
            CreateWarpLine(game, 100, solSystem, acSystem, 10, new Point() { X = 5, Y = 5 });
*/

        }

        private static void CreateRaces(IStellaArdensGame game)
        {
            Race terrans = new Race() {
                Bank = 0,
                Name = "Terran",
                RaceId = GameStandardIds.RACEID_TERRANS,
            };
            game.AddRace(terrans);
            Race orions = new Race()
            {
                Bank = 0,
                Name = "Orions",
                RaceId = GameStandardIds.RACEID_ORION,
            };
            game.AddRace(orions);


            /*
            Nation terrans = game.AddNation(new Nation() { Id = 1, Name = "Terran Empire", ShortName = "Terrans", StratgicPriorities = null });
            game.AddNation(new Nation() { Id = 2, Name = "Orion Khanate", ShortName = "Orions", StratgicPriorities = null });
            game.AddNation(new Nation() { Id = 3, Name = "Rigellian Confederation", ShortName = "Rigellians", StratgicPriorities = null });

            // add known systems
            SolarSystem solSystem = game.GetSolarSystem(GameStandardIds.SOL_SOLARSYSTEMID);
            terrans.KnownSolarSystems.Add(solSystem);
            */
        }


        /*
        private static void CreateFleetsAndTaskForces(StellaArdensGame game)
        {
            Nation terrans = game.GetNation(1);
            Starbase terranShipyard = (Starbase)game.GalacticMap.GetSolarSystemObject(GameStandardIds.SOL_TERRANSHIPYARDID);

            Fleet f1 = game.AddFleet(new Fleet() { FleetId = 1, Name = "Beta Fleet", Nation = terrans, HomeBase = terranShipyard, FleetAllocation = FleetAllocation.Unallocated });
            Fleet f2 = game.AddFleet(new Fleet() { FleetId = 2, Name = "Attack Fleet", Nation = terrans, HomeBase = terranShipyard, FleetAllocation = FleetAllocation.Unallocated });
            Fleet f3 = game.AddFleet(new Fleet() { FleetId = 3, Name = "Zeta Fleet", Nation = terrans, HomeBase = terranShipyard, FleetAllocation = FleetAllocation.Unallocated });
            Fleet f4 = game.AddFleet(new Fleet() { FleetId = 4, Name = "Survey Fleet", Nation = terrans, HomeBase = terranShipyard, FleetAllocation = FleetAllocation.Survey });

            TaskForce tf1 = game.AddTaskForce(new TaskForce() { TaskForceId = 11, Name = "Task Foce Victor", Fleet = f1 });
            TaskForce tf2 = game.AddTaskForce(new TaskForce() { TaskForceId = 12, Name = "Task Foce Able", Fleet = f1 });
            TaskForce tf3 = game.AddTaskForce(new TaskForce() { TaskForceId = 13, Name = "Task Foce Charle", Fleet = f1 });
            TaskForce tf4 = game.AddTaskForce(new TaskForce() { TaskForceId = 14, Name = "Task Foce Boxer", Fleet = f2 });
            TaskForce tf5 = game.AddTaskForce(new TaskForce() { TaskForceId = 15, Name = "Task Foce Zebra", Fleet = f3 });

        }


        private static void CreateMap(StellaArdensGame game, int size)
        {
            game.GalacticMap = new GalacticMap(size);

            // create solar systems
            SolarSystem solSystem = new SolarSystem() { SolarSystemId = GameStandardIds.SOL_SOLARSYSTEMID, Name = "Sol", Location = new Point() { X = 5, Y = 5 } };
            game.AddSolarSystem(solSystem);

            // create bodies
            Planet earth = (Planet)game.AddSolarSystemObject(new Planet() { SolarSystemObjectId = GameStandardIds.SOL_EARTHID, Name = "Earth", SolarSystem = solSystem });
            Planet mars = (Planet)game.AddSolarSystemObject(new Planet() { SolarSystemObjectId = GameStandardIds.SOL_MARSID, Name = "Mars", SolarSystem = solSystem });

            Starbase terranShipyard = (Starbase)game.AddSolarSystemObject(new Starbase() { SolarSystemObjectId = GameStandardIds.SOL_TERRANSHIPYARDID, Name = "Terran Shipyard", SolarSystem = solSystem });

            // create other systems
            SolarSystem acSystem = CreateSolarSystem(game, "Alpha Centaurii", 100, new Point() { X = 5, Y = 5 });


            // create warplines
            CreateWarpLine(game, 100, solSystem, acSystem, 10, new Point() { X = 5, Y = 5 });


        }

        private static void CreateWarpLine(StellaArdensGame game, int warpLineId, SolarSystem srcSS, SolarSystem destSS, int size, Point p)
        {
            WarpLine src = new WarpLine()
            { SolarSystemObjectId = warpLineId, SolarSystem = srcSS, Location = p, Name = destSS.Name + " Warp Line" };
            game.AddSolarSystemObject(src);

            WarpLine dest = new WarpLine()
            { SolarSystemObjectId = warpLineId, SolarSystem = destSS, Location = p, Name = srcSS.Name + " Warp Line" };
            game.AddSolarSystemObject(dest);

            src.DestinationWarpLine = dest;
            dest.DestinationWarpLine = src;
        }

        private static SolarSystem CreateSolarSystem(StellaArdensGame game, string name, int id, Point p)
        {
            SolarSystem solarSystem = new SolarSystem() { SolarSystemId = id, Name = name, Location = p };
            game.AddSolarSystem(solarSystem);
            return solarSystem;
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
        */
    }
}

