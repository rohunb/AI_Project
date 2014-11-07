using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    public enum MissionType { EXTERMINATE, DESTROY_SPACE_STATION, DEFENT_SPACE_STATION, ESCORT_SHIP, ATTACK_PLANET, DEFEND_PLANET }
    class General
    {
        private List<ShipBlueprint> availableShips;
        public List<ShipBlueprint> AvailableShips
        {
            get { return availableShips; }
            set { availableShips = value; }
        }
        private List<ShipBlueprint> currentFleet;
        public List<ShipBlueprint> CurrentFleet
        {
            get { return currentFleet; }
            set { currentFleet = value; }
        }
        public General()
        {

            Console.WriteLine("General Created");

            availableShips = new List<ShipBlueprint>();
            currentFleet = new List<ShipBlueprint>();

            availableShips.Add(new ShipBlueprint());
            currentFleet.Add(new ShipBlueprint());
        }

        public List<AI_Objective> GenerateObjectives(MissionType type)
        {
            return new List<AI_Objective>();
        }

        public void ProcessBattleReport(BattleReport report)
        {

        }

        public List<ShipBlueprint> CalculateFleetForMission(List<AI_Objective> objectives)
        {
            return new List<ShipBlueprint>();
        }
    }
}
