using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace StellaArdens.Core.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class Ship : NamedGameOject
    {
        public int ShipId { get; set; }
        /// <summary>
        /// What division this ship belongs to
        /// </summary>
        public Division Division { get; set; }

        /// <summary>
        /// What design
        /// </summary>
        public Design Design { get; set; }
    }
}
