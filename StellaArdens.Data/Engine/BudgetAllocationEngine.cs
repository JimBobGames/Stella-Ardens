﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Engine
{
    public enum BudgetAreas
    {
        SurveyAndExploration = 1,
        ResearchAndDevelopment = 2,
        Defensive = 3,
        Offensive = 4,
        Economic = 5,
        Diplomacy = 6,
        Reserve = 7
    }

    /// <summary>
    /// Allocate the budget
    /// </summary>
    internal class BudgetAllocationEngine : AbstractEngine
    {
        /// <summary>
        /// Allocate the money for this specifc area
        /// </summary>
        /// <param name="area"></param>
        /// <param name="currentTotalBudget"></param>
        /// <param name="moneyAvailable"></param>
        /// <returns></returns>
        internal int GetBudgetFor(BudgetAreas area, int currentTotalBudget, int moneyAvailable)
        {
            return 0;
        }


    }
   
}
