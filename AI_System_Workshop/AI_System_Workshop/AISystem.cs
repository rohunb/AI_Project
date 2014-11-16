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
        private SortedList<int, AI_Objective> currentObjectives;
        private BattleReport lastBattleReport;

        General general = new General();
        Commander commander = new Commander();

        public AISystem()
        {
            currentFleet = new List<ShipBlueprint>();
            currentObjectives = new SortedList<int, AI_Objective>();
            lastBattleReport = null;

            GameController.Instance.OnPreSceneChange+=OnPreSceneChange;
            GameController.Instance.OnPostSceneChange += OnPostSceneChange;
        }

        public void OnPreSceneChange(PreSceneChangeArgs args)
        {
            //DEBUG
            Console.WriteLine("OnPreSceneChange Called");
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

            switch (args.CurrentScene)
            {
                case GameScene.MainMenu:
                    break;
                case GameScene.GalaxyMap:
                    //if switching from Galaxy to Combat the general has to generate ai_objectives and a fleet
                    if (args.NextScene == GameScene.CombatScene)
                    {
                        general.GenerateObjectivesAndFleet(MissionController.Instance.CurrentMission, ref currentObjectives, ref currentFleet);
                        
                    }
                    break;
                case GameScene.CombatScene:
                    //if switching from Combat to Galaxy, the BattleReport is retrieved from the commander
                    if(args.NextScene == GameScene.GalaxyMap)
                    {
                        lastBattleReport = commander.GetBattleReport();
                    }
                    break;
                case GameScene.ShipDesignScene:
                    break;
                default:
                    break;
            }
            //data saves regardless of transition
            SaveData();
        }

        public void OnPostSceneChange(PostSceneChangeArgs args)
        {
            Console.WriteLine("OnPostSCeneChange Called");

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

            LoadData();
            switch (args.CurrentScene)
            {
                case GameScene.MainMenu:
                    break;
                case GameScene.GalaxyMap:
                    //when transitioning from combat to galaxy, the general has to process the battle report
                    if(args.PreviousScene == GameScene.CombatScene)
                    {
                        general.ProcessBattleReport(lastBattleReport);
                    }
                    break;
                case GameScene.CombatScene:
                    //assuming transition from galaxy map since the player would only end up in a combat scenario from the galaxy map - may change
                    commander.CurrentFleet = currentFleet
                                                .Select(s => ShipBuilder.Instance.BuildShip(s) as AI_Unit)
                                                .ToList();
                    commander.CurrentObjectives = currentObjectives;
                    commander.PrepareForBattle();

                    break;
                case GameScene.ShipDesignScene:
                    break;
                default:
                    break;
            }

        }
        void SaveData()
        {

        }
        void LoadData()
        {

        }
    }
}
