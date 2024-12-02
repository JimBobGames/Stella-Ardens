using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Objects
{
    public class Unit
    {
        public int UnitId { get; set; }
        public int DesignId { get; set; }
        public required string Name { get; set; }
    }
}
