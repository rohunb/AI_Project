using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    /// <summary>
    /// This is a stub to connect to the ShipBlueprint in Unity
    /// </summary>
    class ShipBlueprint
    {
        AI_Unit.Archetype type;
        public ShipBlueprint()
        {
            Console.WriteLine("ShipBlueprint Created");
            Console.WriteLine("This should hook into Unity's ShipBlueprint class");
        }

        public ShipBlueprint(AI_Unit.Archetype _archetype)
        {
            Console.WriteLine("ShipBlueprint Created");
            type = _archetype;
            Console.WriteLine("Type : " + type.ToString());
            Console.WriteLine("This should hook into Unity's ShipBlueprint class");
        }
    }
}
