using System;

namespace Engine
{
	public class Weapon : Item
	{
		public int MaximumDamage{ get; set; }
		public int MinimumDamage{ get; set; }


		public Weapon(string name, string namePlural, int id, int price, int minimumDamage, int maximumDamage) : base(name, namePlural, id, price)
		{
			MinimumDamage = minimumDamage;
			MaximumDamage = maximumDamage;
		}
	}
}

