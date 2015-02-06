using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Fleet
{
    class Chromosome
    {
       private List<Gene> alleles;
       public List<Gene> Alleles
       {
           get { return alleles; }
           set { alleles = value; }
       }

       static int numChromosomes = 0;
       public int ID;

        public Chromosome()
        {
            incrementIDs();
        }

        public Chromosome(Gene _gene)
        {
            initChromosome(_gene);
        }

        private void addOrAppend(Gene _gene)
        {
            if (alleles.Count > 0)
            {
                for (int i = 0; i < alleles.Count; i++)
                {
                    if (alleles[i].Placement == _gene.Placement && alleles[i].Type == _gene.Type)
                    {
                        alleles[i].Count += _gene.Count;
                        alleles[i].ComponentAbilityStat += _gene.ComponentAbilityStat;
                        return;
                    }
                    else
                    {
                        alleles.Add(_gene);
                        return;
                    }
                }
            }
            else
            {
                alleles.Add(_gene);
            }
        }

        public bool willItFit(Gene _gene, ref SlotsPerSection _remainingSlots)
        {
            bool placed = false;
           
            while (!placed)
            {
                if (_gene.Count <= _remainingSlots.getSlot(_gene.Placement))
                {

                    //alleles.Add(_gene);
                    addOrAppend(_gene);
                    _remainingSlots.setSlot(_gene.Placement, (_remainingSlots.getSlot(_gene.Placement) - _gene.Count));
                    placed = true;
                    return true;
                }
                else
                {
                    _gene.Count--;
                    _gene.ComponentAbilityStat = _gene.Count * 100;

                    if (_gene.Count <= 0)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public Chromosome(List<Gene> _alleles)
        {
            initChromosome(_alleles);
        }

        private void initChromosome(List<Gene> _alleles)
        {
            alleles = _alleles;
            incrementIDs();
        }

        private void initChromosome(Gene _gene)
        {
            List<Gene> _alleles = new List<Gene>();
            _alleles.Add(_gene);
            initChromosome(_alleles);
        }

        public void DebugDisplay()
        {
            Console.WriteLine("Chromosome " + ID + " has " + alleles.Count +  " genes");
            Console.WriteLine("~~~~~~~~~~~~~~~~~");
            foreach (Gene gene in alleles)
            {
                gene.DebugDisplay();
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
        }

        private void incrementIDs()
        {
            ID = ++numChromosomes;
        }

        public bool equipGene(Gene _gene)
        {
            return false;
        }
    }
}
