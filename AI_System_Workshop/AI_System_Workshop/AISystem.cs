using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class AISystem
    {
        private List<ShipBlueprint> currentFleet;
        private List<AI_Objective> currentObjectives;
        private BattleReport lastBattleReport;

        General general = new General();
        Commander commander = new Commander();
        
        public AISystem()
        {
            currentFleet = new List<ShipBlueprint>();
        }

       void OnPreSceneChange()
        {
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
        void OnPostSceneChange()
       {
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
