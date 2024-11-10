using StellaArdens.Data.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Objects
{
    public class SolarSystem
    {
        public required int SolarSystemId { get; set; }
        public required string? Name { get; set; }
        public Point Location { get; set; }
        /// <summary>
        /// The survey points for a race
        /// </summary>
        private Dictionary<int, int> surveyPointsByRace = new Dictionary<int, int>();

        public bool IsExplored(Race r)
        {
            // has this been surveyed ?
            if (surveyPointsByRace.ContainsKey(r.RaceId))
            {
                // get the survey points
                int surveyPoints = surveyPointsByRace[r.RaceId];

                // has this met the criteria
                if (surveyPoints >= SolarSystem.GetSurveyPointsRequired())
                {
                    return true;
                }
            }
            return false;
        }

        private static int GetSurveyPointsRequired()
        {
            // by default 100 - could vary in future by type of sun/ binary system etc
            return 100;
        }
    }
}
