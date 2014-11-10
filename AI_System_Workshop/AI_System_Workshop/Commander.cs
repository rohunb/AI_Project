using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class Commander
    {
        private Dictionary<PlayerUnit, AI_Unit.Archetype> playerShipArchetype_table;
        private List<BattleEventArgs> predictedEvents;
        private Dictionary<BattleEventArgs, Order> possibleEventResponse;
        private List<AI_Objective> currentObjectives;

        public List<AI_Objective> CurrentObjectives
        {
            get { return currentObjectives; }
            set
            {
                Console.WriteLine("Commander's setObjective called");
                currentObjectives = value;
            }
        }


        public Commander()
        {
            Console.WriteLine("Commander created");
            playerShipArchetype_table = new Dictionary<PlayerUnit, AI_Unit.Archetype>();
            TurnBasedCombatSystem.Instance.OnStartTurnCycle += StartTurnCycle;
            TurnBasedCombatSystem.Instance.OnBattleEvent += BattleEvent;


            //DEBUG
            playerShipArchetype_table.Add(new PlayerUnit(), AI_Unit.Archetype.SHOTGUN);
        }

        
        
        public void PrepareForBattle()
        {
            Console.WriteLine("Commander: Preparing For Battle");
            /*
             * Assign Archetypes to all units, including playerShips
             * Determine fleet positioning
             * 
             */

        }
        
        private void DetermineArchetype(Unit unit)
        {

        }

        void StartTurnCycle()
        {
            Console.WriteLine("Commander: Start Turn Cycle called");
        }
        void BattleEvent(BattleEventArgs battleEventArgs)
        {
            Console.WriteLine("Commander: Battle Event called");
        }
        
        void LookAhead()
        {
            
        }
        void AssignOrders()
        {

        }
        BattleReport GetBattleReport()
        {
            return null;
        }
    }
}
