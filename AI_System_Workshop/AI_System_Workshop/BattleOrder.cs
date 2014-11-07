﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    enum BattleOrderType
    {
        DESTROY, DISABLE, DEFEND, FOLLOW, DISTRACT
    }

    class BattleOrder : Order
    {
        private BattleOrderType type;
        public AI_System_Workshop.BattleOrderType Type
        {
            get { return type; }
            set { type = value; }
        }

        public BattleOrder()
        {
            Console.WriteLine("BattleOrder created");
        }
    }
}
