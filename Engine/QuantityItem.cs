using System;

namespace Engine
{
    public class QuantityItem
    {
        public Item Details { get; set; }
        public int Quantity { get; set; }

        public QuantityItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}

