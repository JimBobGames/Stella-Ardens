﻿using StellaArdens.Core.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        internal void AddNation(Nation nation)
        {
            Nations[nation.Id] = nation;
        }

        /// <summary>
        /// The store of nations
        /// </summary>
        private readonly Dictionary<int, Nation> nations = new Dictionary<int, Nation>();

        /// <summary>
        /// The store of fleets
        /// </summary>
        private readonly Dictionary<int, Fleet> fleets = new Dictionary<int, Fleet>();

        /// <summary>
        /// The store of task forces
        /// </summary>
        private readonly Dictionary<int, TaskForce> taskForces = new Dictionary<int, TaskForce>();

        /// <summary>
        /// The store of divisions
        /// </summary>
        private readonly Dictionary<int, Division> divisions = new Dictionary<int, Division>();

        /// <summary>
        /// The store of ships
        /// </summary>
        private readonly Dictionary<int, Ship> ships = new Dictionary<int, Ship>();

        internal void AddDesign(Design design)
        {
            Designs[design.Id] = design;
        }

        /// <summary>
        /// The store of designs
        /// </summary>
        private readonly Dictionary<int, Design> designs = new Dictionary<int, Design>();

        public Dictionary<int, GunData> GunData { get; } = new Dictionary<int, GunData>();

        public Dictionary<int, Nation> Nations
        {
            get
            {
                return nations;
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

        /// <summary>
        /// Get a list of task forces, typically one of the fleet id OR the task force id will be 0 (invalid)
        /// </summary>
        /// <param name="fleetId"></param>
        /// <param name="taskForceId"></param>
        /// <returns></returns>
        public List<TaskForce> GetTaskForceList(int fleetId, int taskForceId)
        {
            List<TaskForce> taskForces = new List<TaskForce>();

            Fleet f = GetFleet(fleetId);
            if (f != null)
            {
                List<int> l = f.TaskForces;
                foreach(int i in l)
                {
                    taskForces.Add(GetTaskForce(i));
                }
            }

            TaskForce tf = GetTaskForce(taskForceId);
            if(tf != null)
            {
                taskForces.Add(tf);
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
    }
}