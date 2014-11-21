using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class AI_Tactic
    {
        private List<Order> orders;
        public List<Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }
    }
}
