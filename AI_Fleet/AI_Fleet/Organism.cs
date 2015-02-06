using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Fleet
{
    public enum OrganismHull { CORVETTE, FRIGATE, CRUISER, BATTLESHIP, COUNT }
    public enum OrganismArchetype { SNIPER, TANK, SUPPORT, DPS, COUNT }

    struct SlotsPerSection
    {
        private int forward;
        private int aft;
        private int port;
        private int starboard;

        private int maxSlots;
        public int MaxSlots
        {
            get { return maxSlots; }
            private set { maxSlots = value; }
        }
        private int remainingSlots;
        public int RemainingSlots
        {
            get { return remainingSlots; }
            set { remainingSlots = value; }
        }
        public void setSlots(SlotsPerSection _slots)
        {
            forward = _slots.forward;
            aft = _slots.aft;
            port = _slots.port;
            starboard = _slots.starboard;
            maxSlots = _slots.forward + _slots.aft + _slots.port + _slots.starboard;
            remainingSlots = maxSlots;
        }

        public void setSlot(PlacementType _placement, int _value)
        {
            switch (_placement)
            {
                case PlacementType.FORWARD:
                    forward = _value;
                    break;
                case PlacementType.AFT:
                    aft = _value;
                    break;
                case PlacementType.PORT:
                    port = _value;
                    break;
                case PlacementType.STARBOARD:
                    starboard = _value;
                    break;
                default:
                    break;
            }
        }

        public int getSlot(PlacementType _placement)
        {
            int slots = 0;
            switch (_placement)
            {
                case PlacementType.FORWARD:
                    slots = forward;
                    break;
                case PlacementType.AFT:
                    slots = aft;
                    break;
                case PlacementType.PORT:
                    slots = port;
                    break;
                case PlacementType.STARBOARD:
                    slots = starboard;
                    break;
                default:
                    break;
            }

            return slots;
        }
    }

    class Organism
    {
        private SlotsPerSection slots;
        public AI_Fleet.SlotsPerSection Slots
        {
            get { return slots; }
            set { slots = value; }
        }

        private List<Chromosome> genome;
        public List<Chromosome> Genome
        {
            get { return genome; }
            set { genome = value; }
        }

        private static uint numOrganisms;
        public uint ID;

        private OrganismHull hull;
        public AI_Fleet.OrganismHull Hull
        {
            get { return hull; }
            set { hull = value; }
        }

        private OrganismArchetype archetype;
        public AI_Fleet.OrganismArchetype Archetype
        {
            get { return archetype; }
            set { archetype = value; }
        }

        private int NumGenesByHull(OrganismHull _hull)
        {
            int numberOfGenes = 0;
            /*
            switch (_hull)
            {
                case OrganismHull.CORVETTE:
                    // 5 - 10 Genes
                    numberOfGenes = RandomManager.randomInt(30,50);
                    break;
                case OrganismHull.FRIGATE:
                    // 7 - 14 Genes
                    numberOfGenes = RandomManager.randomInt(20, 30);
                    break;
                case OrganismHull.CRUISER:
                    //9 - 18 Genes
                    numberOfGenes = RandomManager.randomInt(20, 30);
                    break;
                case OrganismHull.BATTLESHIP:
                    //12 - 23 Genes
                    numberOfGenes = RandomManager.randomInt(20, 30);
                    break;
                default:
                    break;
            }
            */
            numberOfGenes = RandomManager.randomInt(30, 50);
            return numberOfGenes;
        }

        private List<Chromosome> GenerateChromosomes(int _variation)
        {
            List<Chromosome> chromosomes = new List<Chromosome>();
            for (int i = 0; i < _variation; i++)
            {
                chromosomes.Add(new Chromosome());
                chromosomes[i].Alleles = new List<Gene>();
            }
            return chromosomes;
        }

        private enum EquipPhase {WEAPONS, THRUSTERS, DEFENSE, SUPPORT, SCANNERS }

        private Chromosome PopulateChromosome(Chromosome _chromosome, int _numGenes, ref SlotsPerSection _remainingSlots)
        {
            
            for (int i = 0; i < _numGenes; i++)
            {
                _chromosome.willItFit(new Gene(hull), ref _remainingSlots);
            }
            return _chromosome;
        }

        public Organism()
        {
            
            //assign a completely random genome
            hull = (OrganismHull)(RandomManager.rollDwhatever((int)OrganismHull.COUNT));
            archetype = (OrganismArchetype)(RandomManager.rollDwhatever((int)OrganismArchetype.COUNT));
            genome = new List<Chromosome>();

            initOrganism();
            SlotsPerSection remainingSlots = slots;
            
            int numGenes = NumGenesByHull(hull);
            genome = GenerateChromosomes(2);

            foreach (Chromosome chromosome in genome)
            {
                remainingSlots.setSlots(slots);
                PopulateChromosome(chromosome, numGenes, ref remainingSlots);
            }
        }

        public Organism(List<Chromosome> _genome, OrganismHull _hull = OrganismHull.CORVETTE, OrganismArchetype _archetype = OrganismArchetype.SNIPER)
        {
            hull = _hull;
            archetype = _archetype;
            genome = _genome;
            initOrganism();
        }

        private void initOrganism()
        {
            incrementIDs();
            assignSlots();
        }

        private void incrementIDs()
        {
            ID = ++numOrganisms;
        }

        private void assignSlots()
        {
            switch (hull)
            {
                case OrganismHull.CORVETTE:
                    slots.setSlot(PlacementType.FORWARD, 9);
                    slots.setSlot(PlacementType.AFT, 9);
                    slots.setSlot(PlacementType.PORT, 7);
                    slots.setSlot(PlacementType.STARBOARD, 6);
                    break;
                case OrganismHull.FRIGATE:
                    slots.setSlot(PlacementType.FORWARD, 9);
                    slots.setSlot(PlacementType.AFT, 11);
                    slots.setSlot(PlacementType.PORT, 14);
                    slots.setSlot(PlacementType.STARBOARD, 14);
                    break;
                case OrganismHull.CRUISER:
                    slots.setSlot(PlacementType.FORWARD, 21);
                    slots.setSlot(PlacementType.AFT, 21);
                    slots.setSlot(PlacementType.PORT, 14);
                    slots.setSlot(PlacementType.STARBOARD, 14);
                    break;
                case OrganismHull.BATTLESHIP:
                    slots.setSlot(PlacementType.FORWARD, 27);
                    slots.setSlot(PlacementType.AFT, 28);
                    slots.setSlot(PlacementType.PORT, 18);
                    slots.setSlot(PlacementType.STARBOARD, 18);
                    break;
                default:
                    break;
            }
        }

        private ShipBluePrint BluePrintFromChromosomes(List<Chromosome> _genome)
        {
            return new ShipBluePrint();
        }

        public void DebugDisplay()
        {
            Console.WriteLine("Organism ID: " + ID + " hull: " + hull + " archetype: " + archetype);
            Console.WriteLine("____________________________________________________________________");
            foreach (Chromosome chromosome in genome)
            {
                chromosome.DebugDisplay();
            }
            Console.WriteLine("____________________________________________________________________");
        }


    }
}