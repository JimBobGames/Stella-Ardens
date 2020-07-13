using System;
using System.Collections.Generic;
using System.Text;

namespace StellaArdens.Core.Data
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    /// <summary>
    /// A hyerspatial connection between 2 points
    /// </summary>
    public class WarpLine : SolarSystemObject
    {
        /// <summary>
        /// The id
        /// </summary>
        public int WarpLineId { get; set; }
        /// <summary>
        /// The maximum size of a ship that can pass the warp line
        /// </summary>
        public int WarpLineSize { get; set; }

        /// <summary>
        /// The id
        /// </summary>
        public WarpLine DestinationWarpLine { get; set; }

    }
}
