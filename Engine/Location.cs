using System;
using System.Collections.Generic;

namespace Engine
{
    public class Location
    {
        public List<EnemyShip> Enemies;
        public string Name{ get; set; }
        public int ID{ get; set; }

        public Location(string name, int id)
        {
            Name = name;
            ID = id;
            Enemies = new List<EnemyShip>();
        }

        public void AddEnemy(EnemyShip enemy, int amount = 1)
        {
            for (int i = 0; i < amount; i++)
            {
                Enemies.Add(enemy);
            }
        }

        public void RemoveEnemy(EnemyShip enemy, int amount = 1)
        {
            for (int i = 0; i < amount; i++)
            {
                Enemies.Remove(enemy);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}