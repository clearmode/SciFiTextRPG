using System;
using System.Collections.Generic;

namespace Engine
{
	public class Mission
	{
		public string Name{ get; set; }
        public int ID{ get; set; }
		public string Description{ get; set; }
		public int ExperienceReward{ get; set; }
		public int MoneyReward{ get; set; }
        public bool IsCompleted{ get; set; }
        public List<QuantityItem> ItemsRequiredForCompletion{ get; set; }
        public List<EnemyShip> KillsRequiredForCompletion{ get; set; }
        public List<QuantityItem> ItemRewards{ get; set; }

        public Mission (string name, int id, string description, int experienceReward, int moneyReward)
		{
			Name = name;
            ID = id;
			Description = description;
			ExperienceReward = experienceReward;
            MoneyReward = moneyReward;
            ItemsRequiredForCompletion = new List<QuantityItem>();
            ItemRewards = new List<QuantityItem>();
            KillsRequiredForCompletion = new List<EnemyShip>();
		}

        public void AddItemRequiredForCompletion(Item itemRequired, int amountRequired = 1)
        {
            ItemsRequiredForCompletion.Add(new QuantityItem(itemRequired, amountRequired));
        }

        public void AddKillRequiredForCompletion(EnemyShip enemy, int numberOfKillsRequired = 1)
        {
            for (int i = 0; i < numberOfKillsRequired; i++)
            {
                KillsRequiredForCompletion.Add(enemy);
            }
        }

        public void AddQuestRewardItem(Item reward, int amount = 1)
        {
            ItemRewards.Add(new QuantityItem(reward, amount));
        }

	}
}

