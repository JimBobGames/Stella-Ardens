using StellaArdens.Data.Game;
using StellaArdens.Data.Objects;
using StellaArdens.Data.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Engine
{
    public class TurnResolutionEngine : AbstractEngine
    {
        public void RunTurn(IStellaArdensGame? game)
        {
            this.Game = game;
            if (game == null)
            {
                return;
            }

            // update the game number
            game.TurnNumber++;
            game.GameEventLog.AddEvent(game.TurnNumber, new GameEvent()
            {
                GameEventCategory = GameEventCategory.InformationEvent,
                GameEventType = GameEventType.TurnUpdateEvent
            });

            // for each race
            foreach (Race r in game.Races)
            {
                RunTurnForRace(r, game);
            }

        }

        private void RunTurnForRace(Race r, IStellaArdensGame game)
        {
            // resolving turn for race
            game.GameEventLog.AddEvent(game.TurnNumber, GameEventCategory.DebugEvent, GameEventType.RacialUpdateEvent, r.RaceId);

            // calaculate income
            ResolveIncome(r);

            // Strategic update - changing priorities
            IReadOnlyList<StratgicPriorities> stratgicPriorities = UpdateStratgicPriorities(game.TurnNumber, r);

            // handle each budget area going from lowest to highest
            foreach (StratgicPriorities sp in stratgicPriorities)
            {
                switch (sp.BudgetAreas)
                {
                    case BudgetAreas.Defensive: ResolveDefensiveSpending(r, sp); break;
                    case BudgetAreas.Diplomacy: ResolveDiplomaticSpending(r, sp); break;
                    case BudgetAreas.Economic: ResolveEconomicSpending(r, sp); break;
                    case BudgetAreas.Offensive: ResolveOffensiveSpending(r, sp); break;
                    case BudgetAreas.ResearchAndDevelopment: ResolveResearchAndDevelopmentSpending(r, sp); break;
                    case BudgetAreas.Reserve: ResolveReserveSpending(r, sp); break;
                    case BudgetAreas.SurveyAndExploration: SurveyAndExplorationEngine.ResolveSurveyAndExplorationSpending(r, sp); break;
                }
            }
           

            // Budget allocation

            // Pay fixed expenses

            // Diplomacy

            // Movement

            // Combat

            // Survey and exploration

            // Defensive (starbases, antipiracy)

            // Offensive (planning offensive missions)

            // Economic spending
        }

        private void ResolveIncome(Race r)
        {
            // iterate thru all the income generation for this race
            int TotalIncome = 0;


            // stub income of 1000;
            TotalIncome = 1000;

            r.Bank += TotalIncome;
            Game.GameEventLog.AddEvent(this.Game.TurnNumber, GameEventCategory.InformationEvent, GameEventType.IncomeUpdateEvent, r.RaceId, TotalIncome, r.Bank);

        }

        internal void ResolveDefensiveSpending(Race r, StratgicPriorities sp)
        {
        }

        internal void ResolveDiplomaticSpending(Race r, StratgicPriorities sp)
        {
        }

        internal void ResolveEconomicSpending(Race r, StratgicPriorities sp)
        {
        }

        internal void ResolveOffensiveSpending(Race r, StratgicPriorities sp)
        {
        }

        internal void ResolveResearchAndDevelopmentSpending(Race r, StratgicPriorities sp)
        {
        }

        internal void ResolveReserveSpending(Race r, StratgicPriorities sp)
        {
        }



        /// <summary>
        /// Updates the allocation of funds to each area. This will vary by the situation and racial preferences 
        /// and of course diplomatic situation
        /// 
        /// Total must be 100
        /// 
        /// Number between 0 and 100
        /// </summary>
        /// <param name="turnNumber"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private IReadOnlyList<StratgicPriorities> UpdateStratgicPriorities(int turnNumber, Race r)
        {
            // update the priorities for each budget area if the has been a change,
            // otherwise use existing one
            List<StratgicPriorities> sp = new List<StratgicPriorities>();
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.Defensive, Value = 10 });
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.Diplomacy, Value = 10 });
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.Economic, Value = 35 });
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.ResearchAndDevelopment, Value = 10 });
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.SurveyAndExploration, Value = 10 });
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.Offensive, Value = 20 });
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.Reserve, Value = 5 });

            // sort lowest to highest
            return sp.OrderBy(o => o.Value).ToList();
        }


        public RaceReport GenerateReportForRace(int raceId, IStellaArdensGame game)
        {
            Race r = game.GetRace(raceId);
            RaceReport rr = new RaceReport() { Name = r.Name };
            rr.TurnNumber = game.TurnNumber;
            rr.Bank = r.Bank;

            return rr;
        }
    }

}
