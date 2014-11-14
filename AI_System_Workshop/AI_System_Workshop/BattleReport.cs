using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class BattleReport
    {
        public bool wonEngagement;
        public int battleDuration;
        public List<MissionObjective> playerObjectives;
        public List<AI_Objective> AI_objectives;
        public Dictionary<Unit, BattleData> battleDatatable;

        public BattleReport()
        {
            Console.WriteLine("BattleReport created");

            playerObjectives = new List<MissionObjective>();
            AI_objectives = new List<AI_Objective>();
            battleDatatable = new Dictionary<Unit, BattleData>();

           // DEBUG/TESTING
            SetupTestReport();
        }

        // DEBUG/TESTING
        private void SetupTestReport()
        {
            Console.WriteLine("Adding test data to Battle Report: won = false, duration = 10, pObjectives = one Mission Objective (blank), AIObjectives = one AI objetive (blank), battleDataTable = a Unit and some BattleData");
            wonEngagement = false;
            battleDuration = 10;
            playerObjectives.Add(new MissionObjective());
            AI_objectives.Add(new AI_Objective());
            battleDatatable.Add(new Unit(), new BattleData());
            battleDatatable.Add(new Unit(), new BattleData());
        }

    }
}
