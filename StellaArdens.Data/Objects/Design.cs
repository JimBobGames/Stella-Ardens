using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Objects
{
    public enum DesignType
    {
        Base = 1,
        Starship = 2,
    }
    public class Design
    {
        public DesignType DesignType { get; set; }
        public int DesignId { get; set; }
        public int RaceId { get; set; }
        public required string Name { get; set; }
        public int Maintainance { get; set; }

        public int TacticalSpeed { get; set; }

        public int StrategicSpeed { get; set; }
    }
}
