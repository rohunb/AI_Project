using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class CombatOrder : Order
    {
        public enum CombatOrderType
        {
            DESTROY, DISABLE, DEFEND, FOLLOW, DISTRACT
        }
        private CombatOrderType type;

        public CombatOrder(CombatOrderType _type)
        {
            Console.WriteLine("CombatOrder created of type " + _type.ToString());
            type = _type;
        }
    }
}
