using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class MissionObjective
    {
        static int numIUnits = 0;
        private int ID;

        public MissionObjective()
        {
            ID = ++numIUnits;
            Console.WriteLine("MissionObjective " + ID + " Created");
        }

        public string displayObjectiveInfo()
        {
            //DEBUG
            return "objective " + ID + ": default debug mission objective";
        }
    }
}
