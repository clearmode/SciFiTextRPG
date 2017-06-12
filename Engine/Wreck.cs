using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Wreck : LivingCreature
    {
        public List<InventoryItem> Loot { get; set; }

        public Wreck(string name, int currentHealth, int maximumHealth) : base(name, currentHealth, maximumHealth)
        {
            Loot = new List<InventoryItem>();
        }
    }
}
