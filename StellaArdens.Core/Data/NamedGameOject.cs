using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Core.Data
{
    public abstract class NamedGameOject : IComparable<NamedGameOject>
    {
        public string Name { get; set; }


        public int CompareTo(NamedGameOject other)
        {
            return Name.CompareTo(other.Name);
        }
    }


}
