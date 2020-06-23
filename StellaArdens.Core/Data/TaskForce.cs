using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Core.Data
{
    public class TaskForce
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// What fleet this ship belongs to
        /// </summary>
        public int FleetId { get; set; }

        private List<int> divisions = new List<int>();

        /// <summary>
        /// The divisions in this task force
        /// /// </summary>
        public List<int> Divisions { get { return divisions; } }

    }
}
