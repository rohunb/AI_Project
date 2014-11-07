using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class General
    {
        private List<ShipBlueprint> availableShips;
        
        private Queue<BattleReport> battleHistory;

        public General()
        {
            Console.WriteLine("General Created");

            availableShips = new List<ShipBlueprint>();

            //DEBUG
            availableShips.Add(new ShipBlueprint());
        }

        public void GenerateObjectives(Mission mission, ref List<AI_Objective> aiObjectives)
        {
            aiObjectives = null;
        }

        public void ProcessBattleReport(BattleReport report)
        {

        }

        public void CalculateFleetForMission(List<AI_Objective> objectives, ref List<ShipBlueprint> currentFleet)
        {
            currentFleet = null;
        }
    }
}
