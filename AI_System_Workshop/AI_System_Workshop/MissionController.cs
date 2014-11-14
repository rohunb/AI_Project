using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class MissionController
    {
        //singleton
        private static MissionController instance = null;
        public static MissionController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MissionController();
                }
                return instance;
            }
        }

        private Mission currentMission;
        public Mission CurrentMission
        {
            get { return currentMission; }
        }

        private MissionController()
        {
            currentMission = new Mission();
        }

    }
}
