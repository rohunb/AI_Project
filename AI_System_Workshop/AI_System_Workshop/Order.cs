using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class Order
    {
        static int numIUnits = 0;
        private int ID;

        public Order()
        {
            ID = ++numIUnits;
            Console.WriteLine("Order Created with ID: " + ID);
        }

        // DEBUG/TESTING
        public int getOrderID()
        {
            //replace with unique identifier
            return ID;
        }

        //DEBUG/TESTING
        public string DisplayOderInfo()
        {
            //DEBUG
            return "order " + ID + ": default debug order";
        }
    }
}
