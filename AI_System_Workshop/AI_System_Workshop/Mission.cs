using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class Mission
    {
        public enum MissionType { EXTERMINATE, DESTROY_SPACE_STATION, DEFENT_SPACE_STATION, ESCORT_SHIP, ATTACK_PLANET, DEFEND_PLANET }
        MissionType missionType;
    }
}
