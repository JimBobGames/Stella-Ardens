using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using StellaArdens.Core.Util;

namespace StellaArdens.Core.Data
{
    /// <summary>
    /// class describing a solar system
    /// </summary>
    public class SolarSystem : NamedGameOject
    {
        /// <summary>
        /// Location of the solar system on the map
        /// </summary>
        public Point Location { get; set; }
        public int SolarSystemId { get; set; }

        public SortedObservableCollection<SolarSystemObject> SolarSystemObjects { get { return solarSystemObjectList; } }

        public SortedObservableCollection<SolarSystemObject> solarSystemObjectList = new SortedObservableCollection<SolarSystemObject>();
    }
}
