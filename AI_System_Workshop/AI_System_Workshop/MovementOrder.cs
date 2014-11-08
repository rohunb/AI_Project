using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class MovementOrder : Order
    {
        public enum MovementOrderType { HOLDPOSITION, RETREAT }

        private MovementOrderType type;
        public MovementOrder(MovementOrderType _type)
        {
            Console.WriteLine("MovementOrder Created of type "+ _type.ToString());
            type = _type;
        }
    }
}
