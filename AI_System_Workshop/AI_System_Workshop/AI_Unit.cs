using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class AI_Unit
    {
        public enum Archetype { TANK, SUPPORT, SCOUT, SNIPER, SHOTGUN, DISABLER, BROADSIDER }

        private Archetype unitArchetype;
        public Archetype UnitArchetype
        {
            get { return unitArchetype; }
            set { unitArchetype = value; }
        }

        private Order currentOrder;
        public Order CurrentOrder
        {
            get { return currentOrder; }
            set { currentOrder = value; }
        }

        public AI_Unit()
        {
            Console.WriteLine("AI_Unit created");
        }

        public float DetermineOrderExecutionViability(Order o)
        {
            return 0.0f;
        }

        public void CalculateNextTurn()
        {

        }
    }
}
