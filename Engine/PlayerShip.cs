using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class PlayerShip : Ship
    {
        //public int MaxCapacitor{ get; set; }
        //public int CurrentCapacitor{ get; set; }
        public int CargoCapacity{ get; set; }
        public int CurrentCargoVolume{ get; set; }
        public List<InventoryItem> Inventory{ get; set; }

        public PlayerShip(string name, int id, int currentHealth, int maximumHealth, int numberOfWeaponSlots, int CargoCapacity/*, int maxCapacitor*/) : base(name, id, currentHealth, maximumHealth, numberOfWeaponSlots)
        {
            //MaxCapacitor = maxCapacitor;
            //CurrentCapacitor = MaxCapacitor;
            Inventory = new List<InventoryItem>();
        }

        public bool AddItemToInventory(Item item, int quantity = 1)
        {
            if ((CurrentCargoVolume + item.Volume * quantity) < CargoCapacity)
            {
                Inventory.Add(new InventoryItem(item, quantity));
                UpdateCargoVolume();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveItemFromInventory(Item item, int quantity = 1)
        {
            InventoryItem invItem = Inventory.SingleOrDefault(x => x.Details == item);

            if(invItem != null && invItem.Quantity > quantity)
            {
                invItem.Quantity -= quantity;
            }
            else if(invItem != null && invItem.Quantity == quantity)
            {
                Inventory.Remove(invItem);
            }
            else
            {
                return false;
            }

            UpdateCargoVolume();

            return true;
        }

        public void UpdateCargoVolume()
        {
            CurrentCargoVolume = Inventory.Sum(x => x.Details.Volume * x.Quantity);
        }

        public override void Explode()
        {
            //TODO reset player to clonebay
        }

        
    }
}

