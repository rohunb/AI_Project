using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    /// <summary>
    /// This is a stub to connect to the Unit in Unity
    /// </summary>
    class Unit
    {
        static int numIUnits = 0;
        private int ID;

        public Unit()
        {
            ID = ++numIUnits;
            Console.Write("Unit Created with ID: " + ID);
            Console.WriteLine(".This should hook into Unity's Unit class");
        }

        // DEBUG/TESTING
        public int getUnitID()
        {
            //replace with unique identifier
            return ID;
        }
    }
}
