using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class Commander
    {
        private Dictionary<PlayerUnit, AI_Unit.Archetype> enemyArchetype_table;
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
            enemyArchetype_table = new Dictionary<PlayerUnit, AI_Unit.Archetype>();

            //DEBUG
            enemyArchetype_table.Add(new PlayerUnit(), AI_Unit.Archetype.SHOTGUN);
        }
        
        void DetermineArchetype(Unit unit)
        {

        }

        void OnBattleEvent(BattleEventArgs battleEvent)
        {

        }
        void LookAhead()
        {

        }
        void AssignOrders()
        {

        }
        BattleReport ReportBattleReport()
        {
            return null;
        }
    }
}
