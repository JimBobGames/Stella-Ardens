using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Objects
{
    public class Race
    {
        public required int Bank { get; set; }
        public required int RaceId { get; set; }
        public required string? Name { get; set; }
    }
}
