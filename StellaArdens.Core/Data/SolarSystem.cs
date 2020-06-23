using System;
using System.Collections.Generic;
using System.Text;

namespace StellaArdens.Core.Data
{
    /// <summary>
    /// class describing a solar system
    /// </summary>
    public class SolarSystem
    {
        /// <summary>
        /// Location of the solar system on the map
        /// </summary>
        public Point Location { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
