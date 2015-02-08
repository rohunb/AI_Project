﻿using System;
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

        private OrganismHull organismHull;
        public AI_Fleet.OrganismHull Hull
        {
            get { return organismHull; }
            set { organismHull = value; }
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
            numberOfGenes = RandomManager.randomInt(20,30);
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

        //TODO: set this up so ship generation follows a more discernible pattern like this:
        //private enum EquipPhase {WEAPONS, THRUSTERS, DEFENSE, SUPPORT, SCANNERS }

        private Chromosome PopulateChromosome(Chromosome _chromosome, int _numGenes, ref SlotsPerSection _remainingSlots)
        {
            
            for (int i = 0; i < _numGenes; i++)
            {
                _chromosome.willItFit(new Gene(organismHull), ref _remainingSlots);
            }
            return _chromosome;
        }

        public Organism()
        {
            
            //assign a completely random genome
            organismHull = (OrganismHull)(RandomManager.rollDwhatever((int)OrganismHull.COUNT));
            archetype = (OrganismArchetype)(RandomManager.rollDwhatever((int)OrganismArchetype.COUNT));
            genome = new List<Chromosome>();

            initOrganism();
            SlotsPerSection remainingSlots = slots;
            
            int numGenes = NumGenesByHull(organismHull);
            genome = GenerateChromosomes(2);

            foreach (Chromosome chromosome in genome)
            {
                remainingSlots.setSlots(slots);
                PopulateChromosome(chromosome, numGenes, ref remainingSlots);
            }
        }

        public Organism(List<Chromosome> _genome, OrganismHull _hull = OrganismHull.CORVETTE, OrganismArchetype _archetype = OrganismArchetype.SNIPER)
        {
            organismHull = _hull;
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
            switch (organismHull)
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

        private Hull OrganismHull2Hull(OrganismHull _organismHull)
        {
            Hull returnHull = new Hull();
            SlotsPerSection slotsLeft = slots;
            int numComponents = slotsLeft.getSlot(PlacementType.FORWARD) + slotsLeft.getSlot(PlacementType.AFT) + slotsLeft.getSlot(PlacementType.PORT) + slotsLeft.getSlot(PlacementType.STARBOARD);
            List<ComponentSlot> shipSlots = new List<ComponentSlot>();

            PlacementType currentlyPopulating = PlacementType.FORWARD;

            for (int i = 0; i < numComponents; i=i)
            {
                ComponentSlot slot = new ComponentSlot();

                if (slotsLeft.getSlot(currentlyPopulating) <= 0)
                {
                    currentlyPopulating++;
                    if (currentlyPopulating == PlacementType.COUNT)
                    {
                        break;
                    }
                }

                slotsLeft.setSlot(currentlyPopulating, (slotsLeft.getSlot(currentlyPopulating) - 1));
                slot.Placement = currentlyPopulating;
                slot.index = i;
                shipSlots.Add(slot);

                i++;
                if (i >= numComponents)
                {
                    break;
                } 
            }
            
            returnHull.EmptyComponentGrid = shipSlots;

            returnHull.Init();

            return returnHull;
        }

        private ShipBlueprint BluePrintFromGene(Gene _gene, Hull _hull)
        {
            ShipBlueprint blueprint = new ShipBlueprint();

            List<ComponentSlot> forwardComponentSlots = new List<ComponentSlot>();
            List<ComponentSlot> aftComponentSlots = new List<ComponentSlot>();
            List<ComponentSlot> portComponentSlots = new List<ComponentSlot>();
            List<ComponentSlot> starboardComponentSlots = new List<ComponentSlot>();

            foreach (ComponentSlot slot in _hull.EmptyComponentGrid)
            {
                switch (slot.Placement)
                {
                    case PlacementType.FORWARD:
                        forwardComponentSlots.Add(slot);
                        break;
                    case PlacementType.AFT:
                        aftComponentSlots.Add(slot);
                        break;
                    case PlacementType.PORT:
                        portComponentSlots.Add(slot);
                        break;
                    case PlacementType.STARBOARD:
                        starboardComponentSlots.Add(slot);
                        break;
                    case PlacementType.COUNT:
                        Console.WriteLine("Invalid Placement Slot in BluePrintFromGene");
                        break;
                    default:
                        break;
                }
            }


            for (int i = 0; i < _gene.Count; i++)
            {
                switch (_gene.Placement)
                {
                    case PlacementType.FORWARD:
                        forwardComponentSlots[i].InstalledComponent = GetComponentByType(_gene.Type);
                        break;
                    case PlacementType.AFT:
                        aftComponentSlots[i].InstalledComponent = GetComponentByType(_gene.Type);
                        break;
                    case PlacementType.PORT:
                        portComponentSlots[i].InstalledComponent = GetComponentByType(_gene.Type);
                        break;
                    case PlacementType.STARBOARD:
                        starboardComponentSlots[i].InstalledComponent = GetComponentByType(_gene.Type);
                        break;
                    case PlacementType.COUNT:
                        break;
                    default:
                        break;
                }
            }

            foreach (ComponentSlot comp in forwardComponentSlots)
            {
                if (comp.InstalledComponent != null)
                {
                    comp.InstalledComponent.Placement = PlacementType.FORWARD;
                    blueprint.AddComponent(comp, comp.InstalledComponent);
                }
            }
            foreach (ComponentSlot comp in aftComponentSlots)
            {
                if (comp.InstalledComponent != null)
                {
                    comp.InstalledComponent.Placement = PlacementType.AFT;
                    blueprint.AddComponent(comp, comp.InstalledComponent);
                }
            }
            foreach (ComponentSlot comp in portComponentSlots)
            {
                if (comp.InstalledComponent != null)
                {
                    comp.InstalledComponent.Placement = PlacementType.PORT;
                    blueprint.AddComponent(comp, comp.InstalledComponent);
                }
            }
            foreach (ComponentSlot comp in starboardComponentSlots)
            {
                if (comp.InstalledComponent != null)
                {
                    comp.InstalledComponent.Placement = PlacementType.STARBOARD;
                    blueprint.AddComponent(comp, comp.InstalledComponent);
                }
            }

            return blueprint;
        }


        private ShipBlueprint BluePrintFromGenes(List<Gene> _genes, Hull _hull)
        {
            ShipBlueprint blueprint = new ShipBlueprint();

            blueprint.hull = _hull;

            foreach (Gene gene in _genes)
	        {
                for (int i = 0; i < gene.Count; i++)
                {
                    ShipComponent component = GetComponentByType(gene.Type);
                    component.Placement = gene.Placement;
                    AddComponentToBluePrint(ref blueprint, component);
                }
	        }
            return blueprint;
        }

        private void AddComponentToBluePrint(ref ShipBlueprint _bluePrint, ShipComponent _component)
        {
            //determine placement
            PlacementType componentPlacement = _component.Placement; 

            List<ComponentSlot> forwardComponentSlots = new List<ComponentSlot>();
            List<ComponentSlot> aftComponentSlots = new List<ComponentSlot>();
            List<ComponentSlot> portComponentSlots = new List<ComponentSlot>();
            List<ComponentSlot> starboardComponentSlots = new List<ComponentSlot>();

            foreach (ComponentSlot slot in _bluePrint.hull.EmptyComponentGrid)
            {
                switch (slot.Placement)
                {
                    case PlacementType.FORWARD:
                        forwardComponentSlots.Add(slot);
                        break;
                    case PlacementType.AFT:
                        aftComponentSlots.Add(slot);
                        break;
                    case PlacementType.PORT:
                        portComponentSlots.Add(slot);
                        break;
                    case PlacementType.STARBOARD:
                        starboardComponentSlots.Add(slot);
                        break;
                    case PlacementType.COUNT:
                        Console.WriteLine("Invalid Placement Slot in BluePrintFromGene");
                        break;
                    default:
                        break;
                }
            }

            List<ComponentSlot> collectionToCheck;

            switch (componentPlacement)
            {
                case PlacementType.FORWARD:
                    collectionToCheck = forwardComponentSlots;
                    break;
                case PlacementType.AFT:
                    collectionToCheck = aftComponentSlots;
                    break;
                case PlacementType.PORT:
                    collectionToCheck = portComponentSlots;
                    break;
                case PlacementType.STARBOARD:
                    collectionToCheck = starboardComponentSlots;
                    break;
                case PlacementType.COUNT:
                    collectionToCheck = new List<ComponentSlot>();
                    break;
                default:
                    collectionToCheck = new List<ComponentSlot>();
                    break;
            }

            //find an open spot

            int nextOpenIndex = 0;
            foreach (ComponentSlot slot in _bluePrint.hull.EmptyComponentGrid)
            {
                if (slot.InstalledComponent == null)
                {
                    nextOpenIndex = slot.index;
                }
            }

            //add the component
            _bluePrint.hull.EmptyComponentGrid[nextOpenIndex].InstalledComponent = _component;

            foreach (ComponentSlot comp in _bluePrint.hull.EmptyComponentGrid)
            {
                if (comp.InstalledComponent != null)
                {
                    comp.InstalledComponent.Placement = _component.Placement;
                    _bluePrint.AddComponent(comp, comp.InstalledComponent);
                }      
            }     
        }


        private ShipComponent GetComponentByType(GeneType _type)
        {
            ShipComponent returnComponent;

            switch (_type)
            {
                case GeneType.LASER:
                    returnComponent = new Comp_Wpn_Laser();
                    break;
                case GeneType.MISSILE:
                    returnComponent = new Comp_Wpn_Missile();
                    break;
                case GeneType.RAILGUN:
                    returnComponent = new Comp_Wpn_Railgun();
                    break;
                case GeneType.FLAK_CANNON:
                    returnComponent = new Comp_Wpn_Flak_Cannon();
                    break;
                case GeneType.FIGHTER_BAY:
                    returnComponent = new Comp_Wpn_Fighter_Bay();
                    break;
                case GeneType.REPAIR_BEAM:
                    returnComponent = new Comp_Wpn_Repair_Beam();
                    break;
                case GeneType.ARMOUR:
                    returnComponent = new Comp_Def_Armour();
                    break;
                case GeneType.SHIELD:
                    returnComponent = new Comp_Def_Shield();
                    break;
                case GeneType.POWERPLANT:
                    returnComponent = new Comp_Pwr_PowerPlant();
                    break;
                case GeneType.THRUSTER:
                    returnComponent = new Comp_Eng_Thruster();
                    break;
                case GeneType.SCANNER:
                    returnComponent = new Comp_Sup_Scanner();
                    break;
                default:
                    returnComponent = new Comp_Wpn_Laser();
                    break;
            }

            return returnComponent;
        }

        private ShipBlueprint BluePrintFromChromosomes(List<Chromosome> _genome)
        {

            return new ShipBlueprint();
        }

        public void DebugDisplay()
        {
            Console.WriteLine("Organism ID: " + ID + " hull: " + organismHull + " archetype: " + archetype);
            Console.WriteLine("____________________________________________________________________");
            foreach (Chromosome chromosome in genome)
            {
                chromosome.DebugDisplay();
            }
            Hull myHUll = OrganismHull2Hull(organismHull);
            ShipBlueprint sbp = BluePrintFromGenes(genome[0].Alleles, myHUll);
            sbp.hull = myHUll;

            for (int i = 0; i < sbp.slot_component_table.Count; i++)
            {
                ComponentSlot cs = sbp.hull.index_slot_table[i];
                if (cs.InstalledComponent == null)
                {
                    Console.Write("{NULL_COMPONENT} "); 
                }
                else
                {
                    Console.Write("{" + sbp.slot_component_table[cs] + " ");
                    Console.Write(sbp.hull.index_slot_table[i].Placement + "} ");
                }
            }
            Console.WriteLine("____________________________________________________________________");
        }
    }
}