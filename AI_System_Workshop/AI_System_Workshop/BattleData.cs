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


        public BattleData()
        {
            unitLifetime = 0;
            orders = new Queue<Order>();
            damageDoneTable = new Dictionary<float, Unit>();
            supportDoneTable = new Dictionary<float, Unit>();
            damageTakenTable = new Dictionary<float, Unit>();
            attackVectorTable = new Dictionary<Unit, Vector3>();
            movements = new Queue<Vector3>();
            orientations = new Queue<float>();

            //DEBUG/TESTING
            SetupDebugData();
        }

        //DEBUG/TESTING
        private void SetupDebugData()
        {
            Unit unit1 = new Unit();
            Unit unit2 = new Unit();

            unitLifetime = 5;
            orders.Enqueue(new Order());
            orders.Enqueue(new Order());
            damageDoneTable.Add(150.0f, unit1);
            damageDoneTable.Add(42.0f, unit2);
            supportDoneTable.Add(15.5f, unit1);
            supportDoneTable.Add(30.0f, unit2);
            damageTakenTable.Add(10.0f, unit1);
            damageTakenTable.Add(200.0f, unit2);
            attackVectorTable.Add(unit1, new Vector3(0.0f, 1.0f, 0.0f));
            attackVectorTable.Add(unit2, new Vector3(1.0f, 1.0f, 0.0f));


        }

    }
}
