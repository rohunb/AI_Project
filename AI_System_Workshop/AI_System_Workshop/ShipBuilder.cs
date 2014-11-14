using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class ShipBuilder
    {
        //singleton
        private static ShipBuilder instance = null;
        public static ShipBuilder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShipBuilder();
                }
                return instance;
            }
        }
        private ShipBuilder()
        {

        }

        public Unit BuildShip(ShipBlueprint shipBlueprint)
        {
            Console.WriteLine("Ship GameObject instantiated from blueprint");
            return new Unit();
        }
    }
}
