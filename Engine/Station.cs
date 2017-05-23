using System;
using System.Collections.Generic;

namespace Engine
{
    public class Station : Location
    {
        private Shop _market;
        public Shop Market
        {
            get { return _market; } 
            set
            {
                _market = value;
                _market.UpdatePriceModifier(SystemSecurityLevel);
            }
        }
        public List<MissionGiver> Agents{ get; set; }
        public CloneBay RespawnPoint{ get; set; }
        public int SystemSecurityLevel{ get; set; }

        public Station(string name, int id, int systemSecurityLevel) : base(name, id)
        {
            Enemies = null;
            SystemSecurityLevel = systemSecurityLevel;
            Agents = new List<MissionGiver>();
        }


    }
}

