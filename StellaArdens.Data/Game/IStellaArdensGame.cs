using StellaArdens.Data.Objects;
using StellaArdens.Data.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Data.Game
{
    public interface IStellaArdensGame
    {
        public int TurnNumber { get; set; }
        public Player Player { get; set; }
        IEnumerable<Race> Races { get; }
        IEnumerable<SolarSystem> SolarSystems { get; }
        IEnumerable<Design> Designs { get; }
        IEnumerable<Fleet> Fleets { get; }
        void AddRace(Race terrans);
        void AddSolarSystem(SolarSystem solarSystem);
        void AddDesign(Design design);
        void AddFleet(Fleet fleet);
        Race? GetRace(int id);
        SolarSystem? GetSolarSystem(int id);

        Design? GetDesign(int id);

        Fleet? GetFleet(int id);

        GameEventLog GameEventLog { get; }

        int NextId();
    }
}
