using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class Mission
    {
        public enum MissionType { EXTERMINATE, DESTROY_SPACE_STATION, DEFEND_SPACE_STATION, ESCORT_SHIP, ATTACK_PLANET, DEFEND_PLANET }
        public MissionType missionType = MissionType.DESTROY_SPACE_STATION;

        public Mission()
        {
            //debug
            Console.WriteLine("Mission has been created");
        }
    }
}
