using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Core.Data
{
    public enum ModuleSize
    {
        NoModule = 0,
        Small = 1, // escorts
        Medium = 2, // cruisers
        Large = 3, // battleships
        Huge = 4, // dreadnoughts
        Starbase = 5, // dreadnoughts

    }
    /// <summary>
    /// The basic module of a ship/starbase
    /// </summary>
    public class Module : NamedGameOject
    {
        public int ModuleId { get; set; }

        public ModuleSize ModuleSize { get; set; }
    }


    public class Weapon : Module
    {
    }
    public class Shield : Module
    {
    }

    public class Engine : Module
    {
    }

}
