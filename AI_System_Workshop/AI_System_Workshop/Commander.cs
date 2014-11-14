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
        private Dictionary<Unit, AI_Unit.Archetype> ShipArchetype_table;
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
            ShipArchetype_table = new Dictionary<Unit, AI_Unit.Archetype>();
            TurnBasedCombatSystem.Instance.OnStartTurnCycle += StartTurnCycle;
            TurnBasedCombatSystem.Instance.OnBattleEvent += BattleEvent;

            
        }

        public void PrepareForBattle()
        {
            Console.WriteLine("Commander: Preparing For Battle");
            /*
             * Assign Archetypes to all units, including playerShips
             * Determine fleet positioning
             * 
             */

            //DEBUG
            playerShipArchetype_table.Add(new PlayerUnit(), AI_Unit.Archetype.SHOTGUN);
            ShipArchetype_table.Add(new Unit(), AI_Unit.Archetype.SNIPER);

        }
        
        private AI_Unit.Archetype DetermineArchetype(Unit unit)
        {
            Console.WriteLine("Commander: DetermineArchetype called");
            return AI_Unit.Archetype.SNIPER;
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
            Console.WriteLine("Commander: LookAhead called");
        }

        void AssignOrders()
        {
            Console.WriteLine("Commander: AssignOrders called");
        }

        public BattleReport GetBattleReport()
        {
            Console.WriteLine("Commander: GetBattleReport called");
            return new BattleReport();
        }
    }
}
