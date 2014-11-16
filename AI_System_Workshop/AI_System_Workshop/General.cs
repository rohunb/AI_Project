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
            availableShips.Add(new ShipBlueprint(AI_Unit.Archetype.SCOUT));
            availableShips.Add(new ShipBlueprint(AI_Unit.Archetype.SNIPER));
            availableShips.Add(new ShipBlueprint(AI_Unit.Archetype.SHOTGUN));
        }


        /// <summary>
        /// Generates objectives based on missionType and parameters;
        /// Then calculates the best possible fleet composition to attain the objectives for the mission
        /// </summary>
        /// <param name="mission"></param>
        /// <param name="aiObjectives"></param>
        /// <param name="currentFleet"></param>
        public void GenerateObjectivesAndFleet(Mission mission, ref SortedList<int, AI_Objective> aiObjectives, ref List<ShipBlueprint> currentFleet)
        {
            Console.WriteLine("General: GenerateObjectivesAndFleet called");

            switch (mission.missionType)
            {
                case Mission.MissionType.EXTERMINATE:
                    Console.WriteLine("Generating Objectives and Fleet for: Exterminate");
                    aiObjectives.Add(1, new AI_Objective(AIObjectiveType.ELIMINATE_ALL_PLAYER_SHIPS));
                    currentFleet = availableShips;
                    break;
                case Mission.MissionType.DESTROY_SPACE_STATION:
                    Console.WriteLine("Generating Objectives and Fleet for: Destroy Space Station");
                    aiObjectives.Add(1, new AI_Objective(AIObjectiveType.DEFEND_STRUCTURE));
                    aiObjectives.Add(2,new AI_Objective(AIObjectiveType.SUPPORT_STRUCTURE));
                    aiObjectives.Add(3, new AI_Objective(AIObjectiveType.ELIMINATE_ALL_PLAYER_SHIPS));
                    currentFleet = availableShips;
                    break;
                case Mission.MissionType.DEFEND_SPACE_STATION:
                    Console.WriteLine("Generating Objectives and Fleet for: Defend Space Station");
                    aiObjectives.Add(1, new AI_Objective(AIObjectiveType.DESTROY_PLAYER_STRUCTURE));
                    aiObjectives.Add(2, new AI_Objective(AIObjectiveType.ELIMINATE_ALL_PLAYER_SHIPS));
                    currentFleet = availableShips;
                    break;
                case Mission.MissionType.ESCORT_SHIP:
                    Console.WriteLine("Generating Objectives and Fleet for: Escort Ship");
                    aiObjectives.Add(1, new AI_Objective(AIObjectiveType.DESTROY_PLAYER_ESCORTED_SHIP));
                    aiObjectives.Add(2, new AI_Objective(AIObjectiveType.ELIMINATE_ALL_PLAYER_SHIPS));
                    currentFleet = availableShips;
                    break;
                case Mission.MissionType.ATTACK_PLANET:
                    Console.WriteLine("Generating Objectives and Fleet for: Attack Planet");
                    aiObjectives.Add(1, new AI_Objective(AIObjectiveType.DEFEND_PLANET));
                    aiObjectives.Add(2, new AI_Objective(AIObjectiveType.SUPPORT_PLANET));
                    aiObjectives.Add(3, new AI_Objective(AIObjectiveType.ELIMINATE_ALL_PLAYER_SHIPS));
                    currentFleet = availableShips;
                    break;
                case Mission.MissionType.DEFEND_PLANET:
                    Console.WriteLine("Generating Objectives and Fleet for: Defend Planet");
                    aiObjectives.Add(1, new AI_Objective(AIObjectiveType.DESTROY_PLAYER_PLANET));
                    aiObjectives.Add(2, new AI_Objective(AIObjectiveType.ELIMINATE_ALL_PLAYER_SHIPS));
                    currentFleet = availableShips;
                    break;
                default:
                    break;
            }

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
                Console.WriteLine(objective.displayObjectiveInfo());
            }
            Console.WriteLine("BattleData table entries: ");
            foreach (KeyValuePair<Unit, BattleData> entry in report.battleDatatable)
            {
                Console.WriteLine("------------------------------------------- - BD Start");
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

                Console.WriteLine("DamageDoneTable:");
                foreach (KeyValuePair<float, Unit> damagePair in entry.Value.damageDoneTable)
                {
                    Console.WriteLine(damagePair.Key + " damage done by Unit ID " + damagePair.Value.getUnitID());
                }

                Console.WriteLine("DamageTakenTable:");
                foreach (KeyValuePair<float, Unit> damagePair in entry.Value.damageTakenTable)
                {
                    Console.WriteLine(damagePair.Key + " damage taken by Unit ID " + damagePair.Value.getUnitID());
                }


                Console.WriteLine("SupportDoneTable:");
                foreach (KeyValuePair<float, Unit> supportPair in entry.Value.supportDoneTable)
                {
                    Console.WriteLine(supportPair.Key + " support from Unit ID " + supportPair.Value.getUnitID());
                }

                Console.WriteLine("AttackVector:");
                foreach (KeyValuePair<Unit, Vector3> atkVectorPair in entry.Value.attackVectorTable)
                {
                    Console.WriteLine(atkVectorPair.Key.getUnitID() + " attacked from vector " + atkVectorPair.Value.x + "," + atkVectorPair.Value.y + "," + atkVectorPair.Value.z);
                }

                foreach (Vector3 movement in entry.Value.movements)
                {
                    Console.WriteLine("Unit " + entry.Key.getUnitID() + " moved to position: " + movement.x + "," + movement.y + "," + movement.z);
                }

                foreach (float orientation in entry.Value.orientations)
                {
                    Console.WriteLine("Unit " + entry.Key.getUnitID() + " faced orientation: " + orientation);
                }

                Console.WriteLine("------------------------------------------- - BD End");

            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ - BR End");
            
        }

    }
}
