using System;

namespace Engine
{
    public class LootItem : QuantityItem
    {
        public double DropRate { get; set; }


        public LootItem(Item details, int quantity, double dropRate) : base (details, quantity)
        {
            DropRate = dropRate;
        }
    }
}

