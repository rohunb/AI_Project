using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class BattleData
    {
        public int unitLifetime;
        public Queue<Order> orders;
                    //damageDone //target
        public Dictionary<float, Unit> damageDoneTable;
                    //supportDone //target 
        public Dictionary<float, Unit> supportDoneTable;
                    //damageTaken //damager
        public Dictionary<float, Unit> damageTakenTable;
                    //damager //attackVector
        public Dictionary<Unit, Vector3> attackVectorTable;
                //position
        public Queue<Vector3> movements;
                //angle
        public Queue<float> orientations;
    }
}
