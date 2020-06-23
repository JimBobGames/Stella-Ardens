using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Core.Data
{
    /// <summary>
    /// What is the role of this divsion? (aka squardron / flotilla)
    /// </summary>
    public enum DivisionRole
    {
        LineOfBattle,
        Escort,
        Scout,
        Survey,
        Transport,
        Tanker
    }

    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// What task force this ship belongs to
        /// </summary>
        public int TaskForceId { get; set; }


        private List<int> ships = new List<int>();

        /// <summary>
        /// The ships in this division
        /// /// </summary>
        public List<int> Ships { get { return ships; } }

    }
}
