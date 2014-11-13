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


        /// <summary>
        /// Generates objectives based on missionType and parameters;
        /// Then calculates the best possible fleet composition to attain the objectives for the mission
        /// </summary>
        /// <param name="mission"></param>
        /// <param name="aiObjectives"></param>
        /// <param name="currentFleet"></param>
        public void GenerateObjectivesAndFleet(Mission mission, ref List<AI_Objective> aiObjectives, ref List<ShipBlueprint> currentFleet)
        {
            Console.WriteLine("General: GenerateObjectivesAndFleet called");
        }

        /// <summary>
        /// Calculates and makes changes to fleet composition and strategy based on results of the battle
        /// </summary>
        /// <param name="report"></param>
        public void ProcessBattleReport(BattleReport report)
        {
            Console.WriteLine("General: ProcessBattleReport called");
        }

    }
}
