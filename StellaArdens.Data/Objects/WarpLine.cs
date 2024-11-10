using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Objects
{
    /// <summary>
    /// a connection between two solar systems
    /// </summary>
    public class WarpLine
    {
        public int SolarSystemIdA { get; set; }
        public int SolarSystemIdB { get; set; }
        public int MaxSize { get; set;  }
    }
}
