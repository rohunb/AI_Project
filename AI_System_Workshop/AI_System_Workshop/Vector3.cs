using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    /// <summary>
    /// This is to stub Unity's Vector3
    /// </summary>
    class Vector3
    {
        public float x, y, z;
        public Vector3()
        {
            
            Console.Write("Vector3 Created .");
            Console.WriteLine("This should hook into Unity's Vector3 class");
            x = y = z = 0.0f;
        }

        public Vector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;

        }

    }
}
