using System;

namespace Engine
{
	public class InventoryItem : QuantityItem
	{
        public double Durability{ get; set; }

        public InventoryItem (Item details, int quantity, double durability = 1) : base (details, quantity)
		{
            Durability = durability;
		}

	}
}

