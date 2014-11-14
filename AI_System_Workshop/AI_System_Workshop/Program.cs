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

            Console.WriteLine();
            Console.WriteLine();
            //AISystem.currState = AISystemState.COMBAT;
            //AISystem.nextState = AISystemState.GALAXY_MAP;

            //testAISystem.OnPreSceneChange();

            ////scene change in Unity
            //Console.WriteLine("~~Change Scene to Galaxy Map~~");

            //testAISystem.OnPostSceneChange();

            //Console.WriteLine();
            //AISystem.nextState = AISystemState.COMBAT;

            //testAISystem.OnPreSceneChange();

            ////scene change in Unity
            //Console.WriteLine("~~Change Scene to Combat Scene~~");

            //testAISystem.OnPostSceneChange();



            //default scene is MainMenu
            GameController.Instance.ChangeScene(GameScene.GalaxyMap); //we should not see a lot of AI processing being called here
            Console.WriteLine("\n");

            GameController.Instance.ChangeScene(GameScene.CombatScene);
            Console.WriteLine("\n");

            GameController.Instance.ChangeScene(GameScene.GalaxyMap);

            Console.ReadLine();
        }
    }
}
