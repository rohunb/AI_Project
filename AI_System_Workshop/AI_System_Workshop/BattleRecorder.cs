using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class BattleRecorder
    {
        private Queue<BattleEventArgs> eventLog;
        public Queue<BattleEventArgs> EventLog
        {
            get { return eventLog; }
        }

        public BattleRecorder()
        {
            Console.WriteLine("BattleRecorder created");
            TurnBasedCombatSystem.Instance.OnBattleEvent+=OnBattleEvent;
        }

        private void OnBattleEvent(BattleEventArgs battleEventArgs)
        {
            Console.WriteLine("BattleRecorder received BattleEvent");
        }

        public BattleReport GenerateBattleReport()
        {
            return new BattleReport();
        }

        
    }
}
