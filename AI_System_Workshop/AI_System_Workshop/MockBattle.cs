﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_System_Workshop
{
    class MockBattle
    {
        private List<Ship> ai_Fleet;
        public List<Ship> AI_Fleet
        {
            get { return ai_Fleet; }
            set { ai_Fleet = value; }
        }

        private List<Ship> playerFleet;
        public List<Ship> PlayerFleet
        {
            get { return playerFleet; }
            set { playerFleet = value; }
        }

        private int numIterations;
        public int NumIterations
        {
            get { return numIterations; }
            set { numIterations = value; }
        }

        private List<BattleEventArgs> recordedEvents;
        public List<BattleEventArgs> RecordedEvents
        {
            get { return recordedEvents; }
            set { recordedEvents = value; }
        }

        private bool inProgress;
        public bool InProgress
        {
            get { return inProgress; }
            set { inProgress = value; }
        }

        private List<Challange> currentChallanges;
        public List<Challange> CurrentChallanges
        {
            get { return currentChallanges; }
            set { currentChallanges = value; }
        }

        public List<Ship> RunRecordedBattle(int _numIterations)
        {
            return new List<Ship>();
        }
    }
}
