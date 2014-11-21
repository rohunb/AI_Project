using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm;

namespace AI_System_Workshop
{
    class Ship : Organism
    {
        private Specification specs;
        public Specification Specs
        {
            get { return specs; }
            set { specs = value; }
        }

        /// <summary>
        /// no-argument constructor
        /// calls base no-argument constructor
        /// </summary>
        public Ship() : base()
        {

        }

        /// <summary>
        /// This constructor takes in a Specification and builds a ship based on it. it also passes the genetic info part to its base class
        /// </summary>
        /// <param name="_geneticInfo"> The Specifications of the ship being made</param>
        public Ship(Specification _geneticInfo) : base(_geneticInfo)
        {

        }
    }
}
