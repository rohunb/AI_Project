using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class Challange
    {
        private AI_Objective objective;
        public AI_Objective Objective
        {
            get { return objective; }
            set { objective = value; }
        }

        private List<ShipBlueprint> enemyFleet;
        public List<ShipBlueprint> EnemyFleet
        {
            get { return enemyFleet; }
            set { enemyFleet = value; }
        }

        private Ship ship;
        public Ship Ship
        {
            get { return ship; }
            set { ship = value; }
        }

        private Planet planet;
        public Planet Planet
        {
            get { return planet; }
            set { planet = value; }
        }

        private Structure structure;
        public Structure Structure
        {
            get { return structure; }
            set { structure = value; }
        }

        public Challange(AI_Objective _objective, List<ShipBlueprint> _enemyFleet)
        {
        }

        public Challange(AI_Objective _objective, Ship _ship)
        {

        }

        public Challange(AI_Objective _objective, Planet _planet)
        {

        }

        public Challange(AI_Objective _objective, Structure structure)
        {

        }
    }
}
