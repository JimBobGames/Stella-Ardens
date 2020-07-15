using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using StellaArdens.Core.Util;

namespace StellaArdens.Core.Data
{
    /// <summary>
    /// A nation state in the game
    /// </summary>
    public class Nation : NamedGameOject
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public int Bank { get; set; }
        public int Income { get; set; }

        public StratgicPriorities StratgicPriorities { get; set; }

        private SortedObservableCollection<Fleet> fleets = new SortedObservableCollection<Fleet>();

        public SortedObservableCollection<Fleet> Fleets
        {
            get
            {
                return fleets;
            }
        }

        private SortedObservableCollection<SolarSystem> knownSolarSystemsList = new SortedObservableCollection<SolarSystem>();

        public SortedObservableCollection<SolarSystem> KnownSolarSystems
        {
            get
            {
                return knownSolarSystemsList;
            }
        }
    }
}
