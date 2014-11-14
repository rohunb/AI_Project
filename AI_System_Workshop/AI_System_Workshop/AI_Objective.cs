using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class AI_Objective
    {
        static int numAI_Obj = 0;
        private int ID;
        public AI_Objective()
        {
            ID = ++numAI_Obj;
            Console.WriteLine("AI_Objective " + ID + " created");
        }

        //DEBUG/TESTING
        public string displayObjectiveInfo()
        {
            return "AI_Objective " + ID + ": default debug AI_=Objective";
        }
    }
}
