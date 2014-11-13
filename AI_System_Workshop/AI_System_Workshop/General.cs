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
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ - BR Start");
            Console.WriteLine("display battle report data:");
            Console.WriteLine("engagement won?: " + report.wonEngagement);
            Console.WriteLine("engagement duration?: " + report.battleDuration);
            Console.WriteLine("Player objectives: ");
            foreach (MissionObjective objective in report.playerObjectives)
            {
                Console.WriteLine(objective.displayObjectiveInfo());
            }
            Console.WriteLine("AI objectives: ");
            foreach (AI_Objective objective in report.AI_objectives)
            {
                Console.WriteLine(objective.ToString());
            }
            Console.WriteLine("BattleData table entries: ");
            foreach (KeyValuePair<Unit, BattleData> entry in report.battleDatatable)
            {
                Console.WriteLine("Unit :" + entry.Key.getUnitID());
                Console.WriteLine("BattleData: ");
                /*
                            //damageDone //target
                public Dictionary<float, Unit> damageDoneTable;
                            //supportDone //target 
                public Dictionary<float, Unit> supportDoneTable;
                            //damageTaken //damager
                public Dictionary<float, Unit> damageTakenTable;
                            //damager //attackVector
                public Dictionary<Unit, Vector3> attackVectorTable;
                        //position
                public Queue<Vector3> movements;
                        //angle
                public Queue<float> orientations;
                 */
                Console.WriteLine("Unit Lifetime: " + entry.Value.unitLifetime);
                Console.WriteLine("Orders: ");
                foreach (Order order in entry.Value.orders)
                {
                    Console.WriteLine(order.DisplayOderInfo());
                }
                Console.WriteLine("Damagedone table:");

                foreach (KeyValuePair<float, Unit> damagePair in entry.Value.damageDoneTable)
                {
                   // Console.WriteLine(damagePair.Key + " damage done by Unit ID " + damagePair.Value.getUnitID());
                }



                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ - BR End");

            }
            
        }

    }
}
