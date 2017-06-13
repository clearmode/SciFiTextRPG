using System;
using System.Linq;
using System.Collections.Generic;

namespace Engine
{
    public class Player : LivingCreature
    {
        public int ExperiencePoints { get; private set; }
        public int Money { get; private set; }

        public PlayerShip CurrentShip { get; private set; }
        public Location CurrentLocation { get; private set; }

        public Station CurrentStation
        {
            get
            {
                if (CurrentLocation is Station)
                {
                    return (Station)CurrentLocation;
                }

                return null;
            }
        }

        public System CurrentSystem
        {
            get
            {
                return World.SystemByLocationID(CurrentLocation.ID);
            }
        }

        public Station CurrentRespawn { get; private set; }

        public List<PlayerMission> Missions { get; private set; }
        public List<EnemyShip> CurrentEnemies { get; private set; }
        public List<Location> WarpableLocations
        {
            get
            {
                List<Location> warpableLocations = new List<Location>();
                foreach (Location loc in CurrentSystem.Locations)
                {
                    if (!loc.Equals(CurrentLocation))
                    {
                        warpableLocations.Add(loc);
                    }
                }

                return warpableLocations;
            }
        }

        private PlayerShip StartingShip { get; set; }

        public event EventHandler PlayerMoved;
        public event EventHandler PlayerDied;
        public event EventHandler<MessageEventArgs> OnMessage;

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

            Missions = new List<PlayerMission>();
            CurrentEnemies = new List<EnemyShip>();

            StartingShip = World.PlayerShipByID(World.PLAYERSHIP_ID_IMPAIROR);
            StartingShip.EquipWeapon(World.ITEM_ID_SMALL_LASER_I, 0);
            StartingShip.EquipWeapon(World.ITEM_ID_SMALL_LASER_I, 1);

            GiveStarterShip();
            MoveTo(World.LOCATION_ID_STATION_AMARR_I);
            SetRespawn(CurrentStation);
        }

        public void KillPlayer()
        {
            PlayerDied?.Invoke(this, EventArgs.Empty);
            CurrentShip = null;
            MoveTo(CurrentRespawn);
        }

        public void SetRespawn(Station station)
        {
            CurrentRespawn = station;
        }

        public void EquipHangarShip(int index)
        {
            if (CurrentShip is null)
            {
                CurrentShip = CurrentStation.ShipHangar.ElementAtOrDefault(index);
                CurrentStation.ShipHangar.RemoveAt(index);
            }
            else
            {
                PlayerShip ship = CurrentShip;
                CurrentStation.ShipHangar.Add(ship);

                CurrentShip = CurrentStation.ShipHangar.ElementAtOrDefault(index);
                CurrentStation.ShipHangar.RemoveAt(index);
            }
        }

        private void GiveStarterShip()
        {
            CurrentShip = new PlayerShip(StartingShip.Name, StartingShip.ID, StartingShip.CurrentHealth, StartingShip.MaximumHealth, StartingShip.NumberOfWeaponSlots, StartingShip.CargoCapacity);
        }

        public void MoveTo(Location location)
        {
            CurrentEnemies.Clear();

            if (location is Station)
            {
                if (CurrentShip is null)
                {
                    if (((Station)location).ShipHangar.Any())
                    {
                        EquipHangarShip(0);
                    }
                    else
                    {
                        GiveStarterShip();
                    }
                }
            }
            else if (location.Enemies.Any())
            {
                foreach (EnemyShip enemy in location.Enemies)
                {
                    CurrentEnemies.Add(new EnemyShip(enemy.Name, enemy.ID, enemy.CurrentHealth, enemy.MaximumHealth, enemy.NumberOfWeaponSlots, enemy.ExperiencePointReward, enemy.MoneyReward));
                }
            }

            CurrentLocation = location;

            PlayerMoved?.Invoke(this, EventArgs.Empty);
        }

        public void MoveTo(int locationID)
        {
            MoveTo(World.LocationByID(locationID));
        }

        public void AttackEnemy(int index)
        {
            int damageDone = CurrentShip.CalculateAttackDamage();

            if (damageDone > 0)
            {
                CurrentEnemies.ElementAt(index).TakeDamage(damageDone);
                RaiseMessage("You hit the " + CurrentEnemies.ElementAt(index) + " for " + damageDone + " damage.");
                
                if (!CurrentEnemies.ElementAt(index).IsAlive)
                {
                    RaiseMessage(CurrentEnemies.ElementAt(index) + " has been destroyed");
                    CurrentEnemies.RemoveAt(index);
                }
            }
            else
            {
                RaiseMessage("Your shots miss");
            }

        }

        private void RaiseMessage(string message, bool addExtraLine = false)
        {
            OnMessage?.Invoke(this, new MessageEventArgs(message, addExtraLine));
        }
    }
}