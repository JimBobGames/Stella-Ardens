using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace StellaArdens.Core.Data
{
    /// <summary>
    /// something in a solar system
    /// </summary>
    public class SolarSystemObject : NamedGameOject
    {
        public int SolarSystemId { get; set; }

        /// <summary>
        /// Location in system 
        /// </summary>
        public Point Location { get; set; }
    }
}
