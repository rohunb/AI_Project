using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{


    class AISystem
    {
        private List<ShipBlueprint> currentFleet;

        General general = new General();
        Commander commander = new Commander();
        
        public AISystem()
        {
            currentFleet = new List<ShipBlueprint>();
        }

    }
}
