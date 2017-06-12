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

        public List<MissionGiver> Agents { get; set; }
        public List<PlayerShip> ShipHangar { get; set; }
        public List<InventoryItem> ItemHangar { get; set; }

        public bool HasCloneBay { get; set; }
        public int SystemSecurityLevel { get; set; }

        public Station(string name, int id, int systemSecurityLevel, bool hasCloneBay) : base(name, id)
        {
            Enemies = null;
            SystemSecurityLevel = systemSecurityLevel;
            HasCloneBay = hasCloneBay;

            Agents = new List<MissionGiver>();
            ShipHangar = new List<PlayerShip>();
            ItemHangar = new List<InventoryItem>();

        }

        public override string ToString()
        {
            return "Station: " + Name;
        }

    }
}

