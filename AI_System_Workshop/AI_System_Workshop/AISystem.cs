using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    public enum AISystemState {GALAXY_MAP,COMBAT,NONE }
    class AISystem
    {
        private List<ShipBlueprint> currentFleet;
        private List<AI_Objective> currentObjectives;
        private BattleReport lastBattleReport;

        public static AISystemState prevState = AISystemState.NONE;
        public static AISystemState currState = AISystemState.NONE;
        public static AISystemState nextState = AISystemState.NONE;
        General general = new General();
        Commander commander = new Commander();

        //testing purposes
        Mission m;
        
        public AISystem()
        {
            currentFleet = new List<ShipBlueprint>();
            currentObjectives = new List<AI_Objective>();
            lastBattleReport = null;

            //testing purposes
            m = new Mission();
        }

       public void OnPreSceneChange()
        {
            Console.WriteLine("OnPreSceneChange Called");
            if (currState == AISystemState.GALAXY_MAP)
            {
                if (nextState == AISystemState.COMBAT)
                {
                    prevState = currState;
                    currState = nextState;

                    //persist objectives and fleet
                    general.GenerateObjectivesAndFleet(m, ref currentObjectives, ref currentFleet);
                    
                }
            }

            if (currState == AISystemState.COMBAT)
            {
                if (nextState == AISystemState.GALAXY_MAP)
                {
                    prevState = currState;
                    currState = nextState;

                    //persist battleReport
                    lastBattleReport = commander.GetBattleReport();

                }
            }
           /*
            * if currentScene == GalaxyMap
            *       if nextScene == CombatScene
            *           get next mission from mission controller
            *           general->generateObjectives
            *           general->calculateFleet
            *           save info for transfer to commander / dontDestroyOnLoad
            * 
            * if currentScene == CombatScene
            *       if nextScene == GalaxyMap
            *           commander->GetBattleReport
            *           
            */
        }

       public void OnPostSceneChange()
       {
           Console.WriteLine("OnPostSCeenChange Called");
           if (currState == AISystemState.COMBAT)
           {
               //commander.SetCurrentFleet(shipBuilder.BuildCurrentFleet(currentFleet));
               commander.CurrentObjectives = currentObjectives;
               commander.PrepareForBattle();
           }

           if (currState == AISystemState.GALAXY_MAP)
           {
               if (prevState == AISystemState.COMBAT)
               {
                   general.ProcessBattleReport(lastBattleReport); 
               }
           }

            /*
             * if currentScene == CombatScene
             *      shipBuilder->buildCurrentFleet
             *      commander->SetCurrentFleet
             *      commander->setObjectives
             *      commander->PrepareForbattle
             *      
             *      
             * if currentScene == GalaxyMap
             *      if prevScene == CombabtScene
             *          general->ProcessBattleReport
             *          
             */ 
       }
    }
}
