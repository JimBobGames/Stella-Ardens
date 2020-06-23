using StellaArdens.Core.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellaArdens.Core.Data
{
    /// <summary>
    /// The strategic priorities for a race
    /// </summary>
    public class StratgicPriorities
    {
        public BudgetAreas BudgetAreas { get; set; }
        public int Value { get; set; }
    }
}
