using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class System
    {
        public string Name{ get; set; }
        public int ID{ get; set; }
        public int SecurityLevel{ get; set; }
        public List<Location> Locations{ get; set; }

        public System(string name, int id, int securityLevel)
        {
            Name = name;
            ID = id;
            SecurityLevel = securityLevel;
            Locations = new List<Location>();
        }

        public override string ToString()
        {
            return Name + " (" + SecurityLevel + ")";
        }

    }
}

