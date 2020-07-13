using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace StellaArdens.Core.Data
{
    public class Fleet : NamedGameOject
    {
        private ObservableCollection<TaskForce> taskForcesList = new ObservableCollection<TaskForce>();

        /// <summary>
        /// The task forces in this division
        /// /// </summary>
        public ObservableCollection<TaskForce> TaskForces { get { return taskForcesList; } }

        public int FleetId { get; set; }

        public Starbase HomeBase { get; set; }
    }

}
