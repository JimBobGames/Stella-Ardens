using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Core.Data
{
    /// <summary>
    /// A nation state in the game
    /// </summary>
    public class Nation
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public int Bank { get; set; }
        public int Income { get; set; }

        public StratgicPriorities StratgicPriorities { get; set; }
    }
}
