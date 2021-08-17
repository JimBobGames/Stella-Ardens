using StellaArdens.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.UI
{
    public class Counter
    {
        /// <summary>
        /// the thing being displayed
        /// </summary>
        public IMapCounter MapCounter { get; set; }

        public Point MapLocation { get; set; }

        public System.Windows.Media.Brush Brush { get; set; }

        public string Name
        {
            get
            {
                if (MapCounter != null)
                {
                    return MapCounter.DetailedName;
                }
                return "";
            }
        }
    }
}
