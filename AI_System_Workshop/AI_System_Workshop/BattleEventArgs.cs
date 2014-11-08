using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{

    class BattleEventArgs
    {
        public enum EventType { DAMAGE, SHIP_DESTRUCTION, DISABLE, REPAIR, SHIELD_REGEN, COMPONENT_DESTRUCTION }

        private EventType battleEventType;
        public EventType BattleEventType
        {
            get { return battleEventType; }
            set { battleEventType = value; }
        }

        public BattleEventArgs()
        {
            Console.WriteLine("BattleEvent created");
        }
    }
}
