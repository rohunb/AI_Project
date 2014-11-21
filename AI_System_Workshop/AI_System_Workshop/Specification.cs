using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm;

namespace AI_System_Workshop
{
    class Specification : Chromosome
    {
        private ShipBlueprint blueprint;
        public AI_System_Workshop.ShipBlueprint Blueprint
        {
            get { return blueprint; }
            set { blueprint = value; }
        }

        private List<AI_Tactic> tactics;
        public List<AI_Tactic> Tactics
        {
            get { return tactics; }
            set { tactics = value; }
        }

        public Specification() : base()
        {

        }

        public Specification(string _newGeneticInfo) : base(_newGeneticInfo)
        {

        }
    }
}
