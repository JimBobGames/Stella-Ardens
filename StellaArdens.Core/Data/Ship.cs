using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Core.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// What division this ship belongs to
        /// </summary>
        public int DivisionId { get; set; }

        /// <summary>
        /// What design
        /// </summary>
        public int DesignId { get; set; }
    }
}
