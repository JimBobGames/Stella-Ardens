using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Core.Data
{
    /// <summary>
    /// a starbase in space, used to supply fleets, construction and defence
    /// </summary>
    public class Starbase : SolarSystemObject
    {
        public Operation StartPoint { get; set; }

        private List<int> fleets = new List<int>();

        /// <summary>
        /// The fleets based at this base
        /// </summary>
        public List<int> Fleets { get { return fleets; } }
    }
}
