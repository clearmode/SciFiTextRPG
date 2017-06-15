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
		public List<Weapon> Weapons { get; set; }

        private double RandomDoubleFromZeroToOne => RandomIntGenerator.NumberBetween(0, 100) / 100.0;
        

        public Ship (string name, int id, int currentHealth, int maximumHealth, int numberOfWeaponSlots)
		{
            ID = id;
			CurrentHealth = currentHealth;
			MaximumHealth = maximumHealth;
			NumberOfWeaponSlots = numberOfWeaponSlots;
			Name = name;
			Weapons = new List<Weapon>();
		}

		public void EquipWeapon(Weapon weapon, int slot)
		{
			if (slot < NumberOfWeaponSlots)
			{
                Weapons.Insert (slot, weapon);
			}
		}

        public void EquipWeapon(int weaponID, int slot)
        {
            EquipWeapon(World.WeaponByID(weaponID), slot);
        }

        public void UnequipWeapon(int slot)
		{
            Weapons.RemoveAt (slot);
		}

		public void TakeDamage(int damage)
		{
			CurrentHealth -= damage;
			if (CurrentHealth <= 0)
			{
				Explode();
			}
		}

        public int CalculateAttackDamage()
        {
            int totalDamage = 0;

            foreach (Weapon weapon in Weapons)
            {
                double shotPrecision = RandomDoubleFromZeroToOne;
                double missChance = 1.0 - weapon.Accuracy;

                if (shotPrecision >= missChance)
                {
                    //weapon hits 
                    totalDamage += RandomIntGenerator.NumberBetween(weapon.MinimumDamage, weapon.MaximumDamage);
                }
                else
                {
                    //weapon misses
                }
            }

            return totalDamage;
        }

		abstract public void Explode();

        public override string ToString()
        {
            return Name + " " + CurrentHealth + "/" + MaximumHealth + " HP";
        }
    }
}

