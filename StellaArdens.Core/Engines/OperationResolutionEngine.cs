using StellaArdens.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellaArdens.Core.Engines
{
    public class OperationResolutionEngine : AbstractEngine
    {
        public void ResolveOperationTurnForNation(Nation n, Operation op)
        {
            DoResolveOperation(op);
        }


        private void DoResolveOperation(Operation op)
        {
        }

    }
}
