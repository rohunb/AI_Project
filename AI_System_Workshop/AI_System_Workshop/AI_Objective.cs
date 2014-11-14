using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    enum AIObjectiveType 
    { 
        NONE,
        DESTROY_PLAYER_ESCORTED_SHIP,
        SUPPORT_ESCORTED_SHIP,
        DEFEND_ESCORTED_SHIP,
        ELIMINATE_ALL_PLAYER_SHIPS,
        DEFEND_STRUCTURE,
        SUPPORT_STRUCTURE,
        DESTROY_PLAYER_STRUCTURE,
        DESTROY_PLAYER_PLANET,
        DEFEND_PLANET,
        SUPPORT_PLANET
    }

    class AI_Objective
    {
        static int numAI_Obj = 0;
        private int ID;

        private AIObjectiveType type;
	    public AIObjectiveType Type
	    {
		    get { return type; }
		    set { type = value; }
	    }

        private Vector3 position;
        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }
        private Unit unit;
        public Unit Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        public AI_Objective()
        {
            assignID();
            type = AIObjectiveType.NONE;
        }

        public AI_Objective(AIObjectiveType _type)
        {
            assignID();
            type = _type;
        }

        public AI_Objective(AIObjectiveType _type, Vector3 _position)
        {
            assignID();
            type = _type;
            position = _position;
        }

        public AI_Objective(AIObjectiveType _type, Unit _unit)
        {
            assignID();
            type = _type;
            unit = _unit;
        }

        public override string ToString()
        {
            return base.ToString() + " ID: " + ID + " target: " + unit.ToString() + " position: " + position.x + "," + position.y + "," + position.z;
        }

        //DEBUG/TESTING
        public string displayObjectiveInfo()
        {
            return "AI_Objective " + ID + ": default debug AI_Objective";
        }

        private void assignID()
        {
            ID = ++numAI_Obj;
            Console.WriteLine("AI_Objective " + ID + " created");
        }
    }
}
