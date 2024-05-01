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


        public void AddRace(Race r)
        {
            races[r.RaceId] = r;
        }

        public void AddSolarSystem(SolarSystem ss)
        {
            solarSystems[ss.SolarSystemId] = ss;
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

        public IReadOnlyList<Race> RacesListUnsorted => races.Values.ToList();
        public IReadOnlyList<Race> RacesListAlphabetical => new List<Race>(races.Values.ToList()).OrderBy(o => o.Name).ToList();
        public IReadOnlyList<Race> RacesListRandom => new List<Race>(ListHelper.Randomize(races.Values.ToList()));
        public Race GetRace(int id)
        {
            races.TryGetValue(id, out Race? value);
            return value;
        }
        public SolarSystem GetSolarSystem(int id)
        {
            solarSystems.TryGetValue(id, out SolarSystem? value);
            return value;
        }
    }
}
