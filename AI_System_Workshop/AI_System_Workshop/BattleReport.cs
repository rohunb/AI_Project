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
        }

    }
}
