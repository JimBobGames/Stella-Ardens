using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Objects
{
    public class Race
    {
        public required int Bank { get; set; }
        public required int RaceId { get; set; }
        public required string? Name { get; set; }

        public RaceSurveyData RaceSurveyData;

        public RacePreferredDeignData RacePreferredDeignData;

        public int TotalIncome;
    }
    /// <summary>
    /// Status information for survey command
    /// </summary>
    public struct RaceSurveyData
    {
        public int Priority = 0;

        public RaceSurveyData()
        {
        }
    }

    public struct RacePreferredDeignData
    {
        public int scoutDesignId = 0;
        public RacePreferredDeignData()
        {
        }
    }
}
