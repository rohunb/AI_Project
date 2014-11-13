using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm;

namespace AI_System_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            //test genetic Algorithm
            //Population pop1 = new Population(10);
            //success 

            AISystem testAISystem = new AISystem();

            TurnBasedCombatSystem.Instance.EventsTester();

            Console.WriteLine();
            AISystem.currState = AISystemState.GALAXY_MAP;
            AISystem.nextState = AISystemState.COMBAT;

            testAISystem.OnPreSceneChange();

            //scene change in Unity
            Console.WriteLine("~~Change Scene to Combat Scene~~");

            testAISystem.OnPostSceneChange();

            Console.WriteLine();
            AISystem.nextState = AISystemState.GALAXY_MAP;

            testAISystem.OnPreSceneChange();

            //scene change in Unity
            Console.WriteLine("~~Change Scene to Galaxy Map~~");

            testAISystem.OnPostSceneChange();

            Console.ReadLine();
        }
    }
}
