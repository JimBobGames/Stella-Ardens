using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace StellaArdens.Core.Data
{
    public class TaskForce : NamedGameOject
    {
        public int TaskForceId { get; set; }
        /// <summary>
        /// What fleet this ship belongs to
        /// </summary>
        public Fleet Fleet { get; set; }

        /// <summary>
        /// The divisions in this task force
        /// /// </summary>
        public ObservableCollection<Division> Divisions { get { return divisionsList; } }

        public ObservableCollection<Division> divisionsList = new ObservableCollection<Division>();
    }

}
