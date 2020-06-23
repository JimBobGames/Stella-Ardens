using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Core.Data
{
    public class Fleet
    {
        private List<int> taskforces = new List<int>();

        /// <summary>
        /// The task forces in this division
        /// /// </summary>
        public List<int> TaskForces { get { return taskforces; } }
    }
}
