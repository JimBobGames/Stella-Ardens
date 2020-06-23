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
            OperationData opdata = ExpandOperation(n, op);
            DoResolveOperation(opdata);
        }

        public OperationData ExpandOperation(Nation n, Operation op)
        {
            // expand out the data and resolve
            OperationData opdata = new OperationData()
            {
                Nation = n,
                Starbase = Game.GalacticMap.GetStarbase(op.StarbaseId),
                TaskForces = Game.GetTaskForceList(op.FleetId, op.TaskForceId),
                TargetSolarSystemObject = Game.GalacticMap.GetSolarSystemObject(op.TargetSolarSystemObjectId),
            };

            return opdata;
        }

        private void DoResolveOperation(OperationData opdata)
        {
        }

        public class OperationData
        {
            public Nation Nation { get; set; }

            /// <summary>
            /// The launching starbase
            /// </summary>
            public Starbase Starbase { get; set; }

            /// <summary>
            /// The fleet 
            /// </summary>
            public List<TaskForce> TaskForces { get; set; }

            public SolarSystemObject TargetSolarSystemObject { get; set; }
        }
    }
}
