using StellaArdens.Core.Hex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Core.Data
{   
    /// <summary>
    /// Displayable on the map
    /// </summary>
    public interface IMapCounter
    {
        string DetailedName { get; }

        HexFacing HexFacing { get; set; }
    }
}
