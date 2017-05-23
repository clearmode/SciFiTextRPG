using System;
using System.Collections.Generic;

namespace Engine
{
	public class EnemyShip : Ship
	{
		public int ExperiencePointReward{ get; set; }
		public int MoneyReward { get; set;}
		public bool IsAlive { get; set; }
		public List<LootItem> ItemDrops { get; set;}

        public EnemyShip (string name, int id, int currentHealth, int maximumHealth, int numberOfWeapons, int experiencePointReward, int moneyReward) : base(name, id, currentHealth, maximumHealth, numberOfWeapons)
		{
			ExperiencePointReward = experiencePointReward;
			MoneyReward = moneyReward;
			IsAlive = true;
			ItemDrops = new List<LootItem>();
		}

		public override void Explode()
		{
			IsAlive = false;

		}

		public void AddItemDrop(Item item, int quantity, double dropRate)
		{
			ItemDrops.Add(new LootItem(item, quantity, dropRate));
		}
	}
}

