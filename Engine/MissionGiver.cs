using System;
using System.Collections.Generic;

namespace Engine
{
    public class MissionGiver
    {
        public List<Mission> Missions{ get; set; }
        public string Name{ get; set; }
        public int ID{ get; set; }
        public int MissionLevel{ get; set; }

        public MissionGiver(string name, int id, int missionLevel)
        {
            Name = name;
            ID = id;
            MissionLevel = missionLevel;
            Missions = new List<Mission>();
        }
    }
}

