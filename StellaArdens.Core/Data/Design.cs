using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Core.Data
{
    public enum DesignSize
    {
        NoSize = 0,
        Escort = 1, // escorts
        Cruiser = 2, // cruisers
        Battleship = 3, // battleships
        Dreadnought = 4, // dreadnoughts
        Starbase = 5, // starbase
    }

    public enum HullSize
    {
        NoSize = 0,

        // Escorts
        Escort = 1, 
        Corvette = 2, 
        Frigate = 3,
        Destroyer = 4,
        LargeDestroyer = 5,

        // cruisers
        LightCruiser = 6, 
        ScoutCruiser = 7,
        HeavyCruiser = 8,
        BattleCruiser = 9,

        // battleships


        // dreadnoughts
    }

    public class Design
    {
        public int Id { get; set; }
        /// <summary>
        /// Indicates the parent design if this is a refit
        /// </summary>
        public int RefitId { get; set; }

        public DesignSize DesignSize { get; set; }
        public string Name { get; set; }
        public int SurveySpeed
        {
            get
            {
                // temp number
                return 4;
            }
        }
    }
}
