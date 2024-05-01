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

        void AddRace(Race terrans);
        void AddSolarSystem(SolarSystem solarSystem);

        Race GetRace(int id);
        SolarSystem GetSolarSystem(int id);

        GameEventLog GameEventLog { get; }
    }
}
