using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class ShipDestructionEventArgs: BattleEventArgs
    {
        private Dictionary<Unit, float> damageSources;
        public Dictionary<Unit, float> DamageSources
        {
            get { return damageSources; }
            set { damageSources = value; }
        }
        private float timeAlive;
        public float TimeAlive
        {
            get { return timeAlive; }
            set { timeAlive = value; }
        }

        public ShipDestructionEventArgs()
        {
            Console.WriteLine("ShipDestructionEvent Created");
        }
    }
}
