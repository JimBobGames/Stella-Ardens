using StellaArdens.Data.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Objects
{
    public class Fleet
    {
        public int FleetId { get; set; }
        public int RaceId { get; set; }
        public required string Name { get; set; }

        /// <summary>
        /// The command the fleet is allocated too
        /// </summary>
        public BudgetAreas BudgetAreas { get; set; }

        private readonly IList<Unit> units = new List<Unit>();

        public IList<Unit> Units
        {
            get
            {
                return units;

            }
        }
    }
}