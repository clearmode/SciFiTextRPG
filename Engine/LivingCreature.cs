using System;

namespace Engine
{
    public class LivingCreature
    {
        public int CurrentHealth{ get; set; }
		public int MaximumHealth{ get; set; }
		public string Name{ get; set; }

        public LivingCreature(string name, int currentHealth, int maximumHealth)
        {
			Name = name;
            CurrentHealth = currentHealth;
            MaximumHealth = maximumHealth;
        }

    }
}