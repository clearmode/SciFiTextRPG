using System;
using System.Collections.Generic;

namespace Engine
{
    public class Player : LivingCreature
    {
		public int ExperiencePoints { get; set; }
		public int Money { get; set; }

        public PlayerShip CurrentShip { get; set; }
        public Location CurrentLocation { get; set; }

        public List<PlayerMission> Missions { get; set; }
        public List<EnemyShip> CurrentEnemies { get; set; }


		public int Level
		{
			get 
			{
				if (ExperiencePoints < 100)
				{
					return 1;
				} 
				else if (ExperiencePoints < 300)
				{
					return 2;
				} 
				else if (ExperiencePoints < 600)
				{
					return 3;
				} 
				else if (ExperiencePoints < 1000)
				{
					return 4;
				} 
				else
				{
					return 5;
				}
			}
		}

		public Player(string name, int currentHealth, int maximumHealth, int money, int experiencePoints) : base(name, currentHealth, maximumHealth)
        {
			Money = money;
			ExperiencePoints = experiencePoints;
        }

        public void KillPlayer()
        {

        }
    }
}