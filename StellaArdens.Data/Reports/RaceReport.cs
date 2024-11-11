using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Reports
{
    public class RaceReport
    {
        public required int RaceId { get; set; }
        public required string Name { get; set; }
         public int TurnNumber { get; set; }
        public int Bank { get; set; }

        public void Display () 
        {
            Debug.WriteLine("RaceReport " + Name + "(" + RaceId + ")");
        }

    }
}
