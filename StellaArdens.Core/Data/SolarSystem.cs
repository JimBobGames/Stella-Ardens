using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using StellaArdens.Core.Util;

namespace StellaArdens.Core.Data
{
    /// <summary>
    /// class describing a solar system
    /// </summary>
    public class SolarSystem : NamedGameOject
    {
        /// <summary>
        /// The survey points for a nation
        /// </summary>
        private Dictionary<int, int> surveyPointsByNation = new Dictionary<int, int>();

        /// <summary>
        /// Location of the solar system on the map
        /// </summary>
        public Point Location { get; set; }
        public int SolarSystemId { get; set; }

        public SortedObservableCollection<SolarSystemObject> SolarSystemObjects { get { return solarSystemObjectList; } }

        public SortedObservableCollection<SolarSystemObject> solarSystemObjectList = new SortedObservableCollection<SolarSystemObject>();

        public bool IsExplored(Nation n)
        {
            // has this been surveyed ?
            if(surveyPointsByNation.ContainsKey(n.Id))
            {
                // get the survey points
                int surveyPoints = surveyPointsByNation[n.Id];

                // has this met the criteria
                if(surveyPoints >= SolarSystem.GetSurveyPointsRequired())
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
