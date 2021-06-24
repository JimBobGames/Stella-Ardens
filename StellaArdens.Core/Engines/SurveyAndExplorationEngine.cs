﻿using StellaArdens.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellaArdens.Core.Engines
{
    /// <summary>
    /// Class which handles the mechanics ofsurvey and exploration
    /// </summary>
    public class SurveyAndExplorationEngine : AbstractEngine
    {

        public int GetSurveyPoints(Ship s)
        {
            if (s == null)
            {
                return 0;
            }
            Design d = s.Design;

            // modified by crew quality perhaps ?
            return d.SurveySpeed;
        }

        public void ResolveSurveyAndExplorationSpending(Nation n, StratgicPriorities sp)
        {
            // how much money ?
            int moneyAvailable = 1000;

            // resolving survey for race
            Game.GameEventLog.AddEvent(Game.TurnNumber, GameEventCategory.InformationEvent, GameEventType.SurveyExplorationUpdateEvent, n.Id, sp.Value, moneyAvailable);

            // how many Unexplored warp lines do we know of ?
            List<WarpLine> unexploredWarpLines = GetUnexploredWarpLines(n);

            // filter any unallocated by 'importance' and access
            List<WarpLine> unallocatedWarpLines = GetUnallocatedWarpLines(n, unexploredWarpLines);

            // allocated available survey fleets
            AllocateSurveyFleets(n, unallocatedWarpLines);

        }

        public void AllocateSurveyFleets(Nation n, List<WarpLine> unallocatedWarpLines)
        {
            // get the idle survey fleets


            // allocate to the warp lines

        }

        public List<WarpLine> GetUnallocatedWarpLines(Nation n, List<WarpLine> unexploredWarpLines)
        {
            // is this 'accessable' ?


            // has a survey fleet been allocated?

            // sort by importance

            return new List<WarpLine>();
        }

        public List<WarpLine> GetUnexploredWarpLines(Nation n)
        {
            // for all 'known' systems
            foreach (SolarSystem ss in n.KnownSolarSystems)
            {
                // is this system explored ??
                if (ss.IsExplored(n))
                {

                }
            }

            return new List<WarpLine>();
        }


    }
}
