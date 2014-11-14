using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    public enum GameScene { MainMenu, GalaxyMap, CombatScene, ShipDesignScene}
    class GameController
    {
        //singleton
        private static GameController instance = null;
        public static GameController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameController();
                }
                return instance;
            }
        }

        private GameScene currentScene = GameScene.MainMenu; 
        public GameScene CurrentScene
        {
            get { return currentScene; }
        }


        public delegate void PreSceneChange(PreSceneChangeArgs args);
        public event PreSceneChange OnPreSceneChange = new PreSceneChange((PreSceneChangeArgs) => { });

        public delegate void PostSceneChange(PostSceneChangeArgs args);
        public event PostSceneChange OnPostSceneChange = new PostSceneChange((PostSceneChangeArgs) => { });

        private GameController()
        {

        }
        //DEBUG
        public void ChangeScene(GameScene nextScene)
        {
            Console.WriteLine("Scene changing from " + currentScene + " to " + nextScene);
            OnPreSceneChange(new PreSceneChangeArgs(currentScene, nextScene));
            
            //The actual scene in Unity changes here
            
            Console.WriteLine("Scene changed to " + nextScene);
            OnPostSceneChange(new PostSceneChangeArgs(currentScene, nextScene));
            currentScene = nextScene;
        }
    }

    public struct PreSceneChangeArgs
    {
        private GameScene currentScene;
        public GameScene CurrentScene
        {
            get { return currentScene; }
        }
        private GameScene nextScene;
        public GameScene NextScene
        {
            get { return nextScene; }
        }

        public PreSceneChangeArgs(GameScene currentScene, GameScene nextScene)
        {
            this.currentScene = currentScene;
            this.nextScene = nextScene;
        }

    }
    public struct PostSceneChangeArgs
    {
        private GameScene previousScene;
        public GameScene PreviousScene
        {
            get { return previousScene; }
        }
        private GameScene currentScene;
        public GameScene CurrentScene
        {
            get { return currentScene; }
        }

        public PostSceneChangeArgs(GameScene previousScene, GameScene currentScene)
        {
            this.previousScene = previousScene;
            this.currentScene = currentScene;
        }
    }
}
