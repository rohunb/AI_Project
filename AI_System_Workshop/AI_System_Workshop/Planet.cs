using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class Planet
    {
        private bool friendly;
        public bool Friendly
        {
            get { return friendly; }
            set { friendly = value; }
        }

        private bool hasOrbitalStation;
        public bool HasOrbitalStation
        {
            get { return hasOrbitalStation; }
            set { hasOrbitalStation = value; }
        }

        private Structure orbitalStation;
        public Structure OrbitalStation
        {
            get { return orbitalStation; }
            set { orbitalStation = value; }
        }
    }
}
