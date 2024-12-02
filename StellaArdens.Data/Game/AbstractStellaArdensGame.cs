using StellaArdens.Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Game
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
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

    public abstract class AbstractStellaArdensGame : IStellaArdensGame
    {
        private readonly GameEventLog eventLog = new GameEventLog();
        public int TurnNumber { get; set; }
        public Player Player { get; set; }

        private int nextId = 1000;
        public int NextId()
        {
            return nextId++;
        }

        public GameEventLog GameEventLog
        {
            get
            {
                return eventLog;
            }
        }
        /// <summary>
        /// The store of races
        /// </summary>
        private readonly Dictionary<int, Race> races = new Dictionary<int, Race>();
        private readonly Dictionary<int, SolarSystem> solarSystems = new Dictionary<int, SolarSystem>();
        private readonly Dictionary<int, Design> designs = new Dictionary<int, Design>();
        private readonly Dictionary<int, Fleet> fleets = new Dictionary<int, Fleet>();

        public void AddRace(Race r)
        {
            races[r.RaceId] = r;
        }

        public void AddSolarSystem(SolarSystem ss)
        {
            solarSystems[ss.SolarSystemId] = ss;
        }
        public void AddDesign(Design d)
        {
            designs[d.DesignId] = d;
        }
        public void AddFleet(Fleet f)
        {
            fleets[f.FleetId] = f;
        }

        public IEnumerable<Race> Races
        {
            get
            {
                return races.Values;
            }
        }
        public IEnumerable<SolarSystem> SolarSystems
        {
            get
            {
                return solarSystems.Values;
            }
        }
        public IEnumerable<Design> Designs
        {
            get
            {
                return designs.Values;
            }
        }
        public IEnumerable<Fleet> Fleets
        {
            get
            {
                return fleets.Values;
            }
        }
        public IReadOnlyList<Race> RacesListUnsorted => races.Values.ToList();
        public IReadOnlyList<Race> RacesListAlphabetical => new List<Race>(races.Values.ToList()).OrderBy(o => o.Name).ToList();
        public IReadOnlyList<Race> RacesListRandom => new List<Race>(ListHelper.Randomize(races.Values.ToList()));
        public Race? GetRace(int id)
        {
            races.TryGetValue(id, out Race? value);
            return value;
        }
        public SolarSystem? GetSolarSystem(int id)
        {
            solarSystems.TryGetValue(id, out SolarSystem? value);
            return value;
        }

        public Design? GetDesign(int id)
        {
            designs.TryGetValue(id, out Design? value);
            return value;
        }

        public Fleet? GetFleet(int id)
        {
            fleets.TryGetValue(id, out Fleet? value);
            return value;
        }
    }
}
