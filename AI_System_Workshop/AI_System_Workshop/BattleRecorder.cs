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
            //DEBUG
            Console.WriteLine("BattleRecorder created");

            TurnBasedCombatSystem.Instance.OnBattleEvent+=OnBattleEvent;
        }

        private void OnBattleEvent(BattleEventArgs battleEventArgs)
        {
            //DEBUG
            Console.WriteLine("BattleRecorder: a BattleEvent was registered");
            Console.WriteLine("Its type is: " + battleEventArgs.BattleEventType.ToString());

            eventLog.Enqueue(battleEventArgs);
        }
        private void OnStartTurnCycle()
        {
            //DEBUG
            Console.WriteLine("BattleRecorder: OnStartTurnCycle");
        }
        public BattleReport GenerateBattleReport()
        {

            //DEBUG
            Console.WriteLine("Generating battle report");

            BattleReport battleReport = new BattleReport();

            //DEBUG/TESTING
            battleReport.wonEngagement = true;



            return new BattleReport();
        }

        
    }
}
