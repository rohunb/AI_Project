using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm;

namespace AI_System_Workshop
{
    class Fleet : Population
    {
        private List<Challange> challanges;
        public List<Challange> Challanges
        {
            get { return challanges; }
            set { challanges = value; }
        }

        private int remainingFleetPoints;
        public int RemainingFleetPoints
        {
            get { return remainingFleetPoints; }
            set { remainingFleetPoints = value; }
        }

        private List<Ship> currentShips;
        public List<Ship> CurrentShips
        {
            get { return currentShips; }
            set { currentShips = value; }
        }

        private List<ShipBlueprint> currentFleet;
        public List<ShipBlueprint> CurrentFleet
        {
            get { return currentFleet; }
            set { currentFleet = value; }
        }

        /// <summary>
        /// This method generates a completely random fleet. 
        /// a good starting point for fleet analysis against 
        /// a totally devastating threat. initially this will 
        /// be used for MockBattle testing
        /// </summary>
        public void GenerateRandomFleet()
        {
            //TODO:
            //1. Randomly generate sensible ship designs
            //2. couple those designs with sensible tactics

            /*
             *
             */
        }

        /// <summary>
        /// This constructor hooks a new fleet to a new 
        /// genetic algorithm
        /// </summary>
        /// <param name="fleetBlueprints"></param>
        public Fleet(List<ShipBlueprint> fleetBlueprints) : base(fleetBlueprints.Capacity)
        {
            foreach (ShipBlueprint blueprint in fleetBlueprints)
            {
                //DEBUG
                Console.WriteLine(blueprint.ToString());

                //1. Make a ship
                //2. assign it tactics from a pool of stored tactics
            }
        }

    }
}
