using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace GeneticAlgorithm
{
    public class Chromosome
    {
        // The genetic info needed for this organism to survive natural selection
        // in this case genetic information will be technology levels, weapon choices, and quantified tactics
        //each "Generation" the genetic info will be tested against an ideal organism and either bred or killed
        
        //for testing purposes to make sure the selection process is working, etc
        private List<string> testGenetics = new List<string>();
        public List<string> TestGenetics
        {
            get { return testGenetics; }
            set { testGenetics = value; }
        }

        const int GENOME_LENGTH = 11;

        public void RandomizeGenome()
        {
            testGenetics.RemoveRange(0, 1);
            testGenetics.Add(Path.GetRandomFileName().Replace(".", ""));

        }

        public Chromosome()
        {
            testGenetics.Add(Path.GetRandomFileName().Replace(".", ""));
        }

        public Chromosome(string _newGeneticInfo)
        {
            testGenetics.Add(_newGeneticInfo.Substring(0,GENOME_LENGTH));
        }
    }
}