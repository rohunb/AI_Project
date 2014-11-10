using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class TurnBasedCombatSystem
    {
        private static TurnBasedCombatSystem instance;

        public static TurnBasedCombatSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TurnBasedCombatSystem();
                }
                return TurnBasedCombatSystem.instance;
            }
        }

        private TurnBasedCombatSystem()
        {
            Console.WriteLine("TurnBasedSystem initiated");
            
        }
        private List<PlayerUnit> playerUnits;
        public List<PlayerUnit> PlayerUnits
        {
            get { return playerUnits; }
        }

        private List<AI_Unit> ai_units;
        public List<AI_Unit> Ai_units
        {
            get { return ai_units; }
        }

        public delegate void BattleEvent(BattleEventArgs battleEventArgs);
        public event BattleEvent OnBattleEvent = new BattleEvent((BattleEventArgs battleEventArgs) => { });

        public delegate void StartTurnCycle();
        public event StartTurnCycle OnStartTurnCycle = new StartTurnCycle(() => { });

        //DEBUG
        public void EventsTester()
        {
            OnStartTurnCycle();
            OnBattleEvent(null);
        }

    }
}
