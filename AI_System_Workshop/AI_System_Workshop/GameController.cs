using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    struct PreSceneChangeArgs
    {

    }
    struct PostSceneChangeArgs
    {

    }
    class GameController
    {
        public delegate void PreSceneChange(PreSceneChangeArgs args);
        public event PreSceneChange OnPreSceneChange = new PreSceneChange((PreSceneChangeArgs) => { });

        public delegate void PostSceneChange(PostSceneChangeArgs args);
        public event PostSceneChange OnPostSceneChange = new PostSceneChange((PostSceneChangeArgs) => { });

        GameController()
        {
 
        }

    }
}
