using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Core.Data
{
    /// <summary>
    /// The hull of a starship
    /// </summary>
    public class Hull : NamedGameOject
    {
        public int HullId { get; set; }
        public DesignSize DesignSize { get; set; }
        public HullSize HullSize { get; set; }
    }
}
