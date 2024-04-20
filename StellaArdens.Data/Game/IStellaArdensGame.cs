using StellaArdens.Data.Objects;
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
    }
}
