using System;
using System.Collections.Generic;

namespace Engine
{
	public abstract class Ship
	{
        public int ID{ get; set; }
		public int NumberOfWeaponSlots{ get; set; }
		public int CurrentHealth{ get; set; }
		public int MaximumHealth{ get; set; }
		public string Name{ get; set;}
		private List<Weapon> _weapons;



        public Ship (string name, int id, int currentHealth, int maximumHealth, int numberOfWeaponSlots)
		{
            ID = id;
			CurrentHealth = currentHealth;
			MaximumHealth = maximumHealth;
			NumberOfWeaponSlots = numberOfWeaponSlots;
			Name = name;
			_weapons = new List<Weapon>();
		}

		public void EquipWeapon(Weapon weapon, int slot)
		{
			if (slot < NumberOfWeaponSlots)
			{
				_weapons.Insert (slot, weapon);
			}
		}

		public void UnequipWeapon(int slot)
		{
			_weapons.RemoveAt (slot);
		}

		public void TakeDamage(int damage)
		{
			CurrentHealth -= damage;
			if (CurrentHealth <= 0)
			{
				Explode();
			}
		}

		abstract public void Explode();
			
	}
}

