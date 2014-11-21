using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class Structure
    {
        private int hp;
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        private Vector3 location;
        public Vector3 Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}
