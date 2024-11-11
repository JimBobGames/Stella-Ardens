using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Reports
{
    public class RaceReport
    {
        public RaceReport() {
            RaceSurveyReport = new RaceSurveyReport();
        }
        public required int RaceId { get; set; }
        public required string Name { get; set; }
         public int TurnNumber { get; set; }
        public int Bank { get; set; }
        public int TotalIncome { get; set; }
        public RaceSurveyReport RaceSurveyReport;

        public void Display () 
        {
            Debug.WriteLine("RaceReport " + Name + "(" + RaceId + "), TotalIncome " + TotalIncome);
            Debug.WriteLine(" Budget " + RaceSurveyReport.Priority);
        }

    }

    public struct RaceSurveyReport()
    {
        public int Priority;
    }

}
