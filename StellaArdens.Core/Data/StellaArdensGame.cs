using StellaArdens.Core.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace StellaArdens.Core.Data
{
    public static class ListHelper
    {
        ///
        /// Shuffles the specified list into a random order.
        ///
        /// The type of the list items
        /// The list of items.
        /// A randomised list of the items.
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            Random rnd = new Random();
            return source.OrderBy<T, int>((item) => rnd.Next());
        }
    }

    /// <summary>
    /// 
    /// The game 'database'
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    public class StellaArdensGame : IStellaArdensGame
    {
        private readonly GameEventLog eventLog = new GameEventLog();

        public int TurnNumber { get; set; }

        public Player Player { get; set; }

        /// <summary>
        /// The galactic map
        /// </summary>
        private GalacticMap map = null;

        public GameEventLog GameEventLog
        {
            get
            {
                return eventLog;
            }
        }


        /// <summary>
        /// The store of engines
        /// </summary>
        //[JsonProperty]
        private readonly Dictionary<int, Engine> engines = new Dictionary<int, Engine>();

        /// <summary>
        /// The store of shields
        /// </summary>
        //[JsonProperty]
        private readonly Dictionary<int, Shield> shields = new Dictionary<int, Shield>();

        /// <summary>
        /// The store of armour
        /// </summary>
        //[JsonProperty]
        private readonly Dictionary<int, Armour> armour = new Dictionary<int, Armour>();

        /// <summary>
        /// The store of nations
        /// </summary>
        [JsonProperty]
        private readonly Dictionary<int, Nation> nations = new Dictionary<int, Nation>();

        /// <summary>
        /// The store of fleets
        /// </summary>
        [JsonProperty]
        private readonly Dictionary<int, Fleet> fleets = new Dictionary<int, Fleet>();

        /// <summary>
        /// The store of task forces
        /// </summary>
        [JsonProperty]
        private readonly Dictionary<int, TaskForce> taskForces = new Dictionary<int, TaskForce>();

        /// <summary>
        /// The store of divisions
        /// </summary>
        [JsonProperty]
        private readonly Dictionary<int, Division> divisions = new Dictionary<int, Division>();

        /// <summary>
        /// The store of ships
        /// </summary>
        private readonly Dictionary<int, Ship> ships = new Dictionary<int, Ship>();

        internal void AddDesign(Design design)
        {
            Designs[design.DesignId] = design;
        }

        internal void AddEngine(Engine engine)
        {
            Engines[engine.ModuleId] = engine;
        }

        /// <summary>
        /// The store of hulls
        /// </summary>
        [JsonProperty]
        private readonly Dictionary<int, Hull> hulls = new Dictionary<int, Hull>();

        /// <summary>
        /// The store of designs
        /// </summary>
        [JsonProperty]
        private readonly Dictionary<int, Design> designs = new Dictionary<int, Design>();


        [JsonProperty]
        public Dictionary<int, GunData> GunData { get; } = new Dictionary<int, GunData>();

        public Dictionary<int, Nation> Nations
        {
            get
            {
                return nations;
            }
        }

        public Dictionary<int, Hull> Hulls
        {
            get
            {
                return hulls;
            }
        }

        public Dictionary<int, Fleet> Fleets
        {
            get
            {
                return fleets;
            }
        }

        public Dictionary<int, TaskForce> TaskForces
        {
            get
            {
                return taskForces;
            }
        }

        public Dictionary<int, Division> Divisions
        {
            get
            {
                return divisions;
            }
        }

        public Dictionary<int, Ship> Ships
        {
            get
            {
                return ships;
            }
        }

        public Dictionary<int, Design> Designs
        {
            get
            {
                return designs;
            }
        }
        public Dictionary<int, Engine> Engines
        {
            get
            {
                return engines;
            }
        }
        public Dictionary<int, Shield> Shields
        {
            get
            {
                return shields;
            }
        }
        public Dictionary<int, Armour> Armour
        {
            get
            {
                return armour;
            }
        }

        public IReadOnlyList<Fleet> FleetListUnsorted => fleets.Values.ToList();

        public IReadOnlyList<Nation> NationsListUnsorted => nations.Values.ToList();
        public IReadOnlyList<Nation> NationsListAlphabetical => new List<Nation>(nations.Values.ToList()).OrderBy(o => o.Name).ToList();
        public IReadOnlyList<Nation> NationsListRandom => new List<Nation>(ListHelper.Randomize(nations.Values.ToList()));
        public Nation GetNation(int id)
        {
            Nations.TryGetValue(id, out Nation value);
            return value;
        }
        public IReadOnlyList<Design> DesignsListUnsorted => designs.Values.ToList();
        public IReadOnlyList<Design> DesignsListAlphabetical => new List<Design>(designs.Values.ToList()).OrderBy(o => o.Name).ToList();
        public Design GetDesign(int id)
        {
            Designs.TryGetValue(id, out Design value);
            return value;
        }

        public IReadOnlyList<Hull> HullsListUnsorted => hulls.Values.ToList();
        public IReadOnlyList<Hull> HullsListAlphabetical => new List<Hull>(hulls.Values.ToList()).OrderBy(o => o.Name).ToList();
        public Hull GetHull(int id)
        {
            Hulls.TryGetValue(id, out Hull value);
            return value;
        }

        public IReadOnlyList<Engine> EnginesListUnsorted => engines.Values.ToList();
        public IReadOnlyList<Engine> EnginesListAlphabetical => new List<Engine>(engines.Values.ToList()).OrderBy(o => o.Name).ToList();
        public Engine GetEngine(int id)
        {
            Engines.TryGetValue(id, out Engine value);
            return value;
        }

        public IReadOnlyList<Shield> ShieldsListUnsorted => shields.Values.ToList();
        public IReadOnlyList<Shield> ShieldsListAlphabetical => new List<Shield>(shields.Values.ToList()).OrderBy(o => o.Name).ToList();
        public Shield GetShield(int id)
        {
            Shields.TryGetValue(id, out Shield value);
            return value;
        }

        public IReadOnlyList<Armour> ArmourListUnsorted => armour.Values.ToList();
        public IReadOnlyList<Armour> ArmourListAlphabetical => new List<Armour>(armour.Values.ToList()).OrderBy(o => o.Name).ToList();
        public Armour GetArmour(int id)
        {
            Armour.TryGetValue(id, out Armour value);
            return value;
        }

        /// <summary>
        /// Get a list of task forces, typically one of the fleet id OR the task force id will be 0 (invalid)
        /// </summary>
        /// <param name="fleetId"></param>
        /// <param name="taskForceId"></param>
        /// <returns></returns>
        public List<TaskForce> GetTaskForceList(Fleet fleet, TaskForce taskForce)
        {
            List<TaskForce> taskForces = new List<TaskForce>();

            if (fleet != null)
            {
                IEnumerable<TaskForce> l = fleet.TaskForces;
                foreach(TaskForce tf in l)
                {
                    taskForces.Add(tf);
                }
            }

            if(taskForce != null)
            {
                taskForces.Add(taskForce);
            }
            return taskForces;
        }

        public GalacticMap GalacticMap
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
            }
        }

        public Fleet GetFleet(int id)
        {
            Fleets.TryGetValue(id, out Fleet value);
            return value;
        }

        public SolarSystem GetSolarSystem(int id)
        {
            map.SolarSystems.TryGetValue(id, out SolarSystem value);
            return value;
        }

        public TaskForce GetTaskForce(int id)
        {
            TaskForces.TryGetValue(id, out TaskForce value);
            return value;
        }
        public Division GetDivision(int id)
        {
            Divisions.TryGetValue(id, out Division value);
            return value;
        }
        public Ship GetShip(int id)
        {
            Ships.TryGetValue(id, out Ship value);
            return value;
        }

        public Fleet AddFleet(Fleet fleet)
        {
            if (fleet != null && fleet.Nation != null || fleet.HomeBase !=null)
            {
                fleets[fleet.FleetId] = fleet;
                fleet.Nation.Fleets.Add(fleet);
                fleet.HomeBase.Fleets.Add(fleet);
            }

            return fleet;
        }

        public Shield AddShield(Shield shield)
        {
            if (shield != null)
            {
                shields[shield.ModuleId] = shield;
            }

            return shield;
        }
        public Armour AddArmour(Armour a)
        {
            if (a != null)
            {
                armour[a.ModuleId] = a;
            }

            return a;
        }

        public TaskForce AddTaskForce(TaskForce taskForce)
        {
            if (taskForce != null && taskForce.Fleet != null)
            {
                taskForces[taskForce.TaskForceId] = taskForce;
                taskForce.Fleet.TaskForces.Add(taskForce);
            }

            return taskForce;
        }


        public SolarSystem AddSolarSystem(SolarSystem solarSystem)
        {
            if (solarSystem != null)
            {
                map.SolarSystems[solarSystem.SolarSystemId] = solarSystem;
            }

            return solarSystem;
        }

        public SolarSystemObject AddSolarSystemObject(SolarSystemObject obj)
        {
            if (obj != null || obj.SolarSystem != null)
            {
                map.SolarSystemObjects[obj.SolarSystemObjectId] = obj;
                obj.SolarSystem.SolarSystemObjects.Add(obj);
            }

            return obj;
        }

        public Nation AddNation(Nation nation)
        {
            Nations[nation.Id] = nation;

            return nation;
        }

        internal Hull AddHull(Hull h)
        {
            Hulls[h.HullId] = h;

            return h;
        }
    }
}
