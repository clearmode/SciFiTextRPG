using System;
using System.Linq;
using System.Collections.Generic;

namespace Engine
{
    public static class World
    {
		public static readonly List<Item> Items = new List<Item>();
        public static readonly List<EnemyShip> Enemies = new List<EnemyShip>();
        public static readonly List<Mission> Missions = new List<Mission>();
        public static readonly List<MissionGiver> MissionGivers = new List<MissionGiver>();
        public static readonly List<System> Systems = new List<System>();
        public static readonly List<PlayerShip> PlayerShips = new List<PlayerShip>();

        public const int ITEM_ID_SLAVE = 0000;
        public const int ITEM_ID_DANCER = 0001;
        public const int ITEM_ID_SOLDIER = 0002;
        public const int ITEM_ID_LIVESTOCK = 0003;
        public const int ITEM_ID_SMALL_LASER_I = 0004;
        public const int ITEM_ID_SMALL_ROCKET_I = 0005;

        public const int LOCATION_ID_STATION_JITA_IV = 1000;
        public const int LOCATION_ID_STATION_AMARR_I = 1001;

        public const int LOCATION_ID_ASTEROID_BELT_JITA_I = 2000;
        public const int LOCATION_ID_ASTEROID_BELT_JITA_II = 2001;
        public const int LOCATION_ID_ASTEROID_BELT_AMARR_I = 2002;
        public const int LOCATION_ID_ASTEROID_BELT_AMARR_II = 2003;
        public const int LOCATION_ID_SUN = 2004;

        public const int LOCATION_ID_GATE_AMARR = 3000;
        public const int LOCATION_ID_GATE_JITA = 3001;

        public const int SYSTEM_ID_JITA = 4000;
        public const int SYSTEM_ID_AMARR = 4001;

        public const int PLAYERSHIP_ID_IMPAIROR = 5000;
        public const int PLAYERSHIP_ID_EXECUTIONER = 5001;

        public const int ENEMYSHIP_ID_PIRATE_ONE = 6000;
        public const int ENEMYSHIP_ID_PIRATE_TWO = 6001;
        public const int ENEMYSHIP_ID_CAPSULEER = 6002;

        public const int SHOP_ID_JITA_IV = 7000;
        public const int SHOP_ID_AMARR_I = 7001;

        public const int CLONE_BAY_ID_JITA_IV = 8000;
        public const int CLONE_BAY_ID_AMARR_I = 8001;

        public const int MISSION_ID_JITA_IV_1 = 9000;
        public const int MISSION_ID_JITA_IV_2 = 9001;
        public const int MISSION_ID_JITA_IV_3 = 9002;
        public const int MISSION_ID_JITA_IV_4 = 9003;

        public const int MISSION_ID_AMARR_I_1 = 9100;

        public const int MISSION_GIVER_ID_JITA_IV_1 = 10000;
        public const int MISSION_GIVER_ID_JITA_IV_2 = 10001;
        public const int MISSION_GIVER_ID_AMARR_I_1 = 10002;

        public const int SECURITY_LEVEL_JITA = 10;
        public const int SECURITY_LEVEL_AMARR = 10;

		static World()
        {
            InitializeItems();
            InitializePlayerShips();
            InitializeEnemies();
            InitializeMissions();
            InitializeMissionGivers();
            InitializeLocations();
		}

        private static void InitializeItems()
        {
            Item slave = new Item("Slave", "Slaves", ITEM_ID_SLAVE, 1);
            Items.Add(slave);

            Item dancer = new Item("Dancer", "Dancers", ITEM_ID_DANCER, 1);
            Items.Add(dancer);

            Item soldier = new Item("Soldier", "Soldiers", ITEM_ID_SOLDIER, 1);
            Items.Add(soldier);

            Item livestock = new Item("Livestock", "Livestock", ITEM_ID_LIVESTOCK, 1);
            Items.Add(livestock);

            Weapon smallLaserI = new Weapon("Small Laser I", "Small Laser I's", ITEM_ID_SMALL_LASER_I, 1000, 10, 20);
            Items.Add(smallLaserI);

            Weapon smallRocketI = new Weapon("Small Rocket I", "Small Rocket I's", ITEM_ID_SMALL_ROCKET_I, 1000, 10, 15);
            Items.Add(smallRocketI);
        }

        private static void InitializePlayerShips()
        {
            PlayerShip executioner = new PlayerShip("Executioner", 1000, 1000, 4, 1000);

        }

        private static void InitializeEnemies()
        {
            EnemyShip pirate1 = new EnemyShip("Pirate One", ENEMYSHIP_ID_PIRATE_ONE, 500, 500, 2, 10, 1000);
            pirate1.EquipWeapon(WeaponByID(ITEM_ID_SMALL_ROCKET_I), 0);
            pirate1.EquipWeapon(WeaponByID(ITEM_ID_SMALL_ROCKET_I), 1);
            Enemies.Add(pirate1);

            EnemyShip pirate2 = new EnemyShip("Pirate Two", ENEMYSHIP_ID_PIRATE_ONE, 500, 500, 2, 10, 1000);
            pirate1.EquipWeapon(WeaponByID(ITEM_ID_SMALL_LASER_I), 0);
            pirate1.EquipWeapon(WeaponByID(ITEM_ID_SMALL_LASER_I), 1);
            Enemies.Add(pirate2);

            EnemyShip capsuleer = new EnemyShip("Hostile Capsuleer", ENEMYSHIP_ID_CAPSULEER, 1000, 1000, 4, 50, 10000);
            capsuleer.EquipWeapon(WeaponByID(ITEM_ID_SMALL_ROCKET_I), 0);
            capsuleer.EquipWeapon(WeaponByID(ITEM_ID_SMALL_ROCKET_I), 1);
            capsuleer.EquipWeapon(WeaponByID(ITEM_ID_SMALL_LASER_I), 2);
            capsuleer.EquipWeapon(WeaponByID(ITEM_ID_SMALL_LASER_I), 3);
            Enemies.Add(capsuleer);
        }

        private static void InitializeMissions()
        {
            Mission jitaIV_1 = new Mission("Clear Asteroid Belt I", MISSION_ID_JITA_IV_1, 
                "Our miners are unable to mine due to pirates in Asteroid Belt I.\n Please go clear them out.", 100, 5000);
            Missions.Add(jitaIV_1);

            Mission jitaIV_2 = new Mission("Clear Asteroid Belt II", MISSION_ID_JITA_IV_2,
                "Our miners are unable to mine due to pirates in Asteroid Belt II.\n Please go clear them out.", 150, 8000);
            Missions.Add(jitaIV_2);
        }

        private static void InitializeMissionGivers()
        {
            MissionGiver jitaIV_1 = new MissionGiver("Jita Military Officer", MISSION_GIVER_ID_JITA_IV_1, 1);
            jitaIV_1.Missions.Add(MissionByID(MISSION_ID_JITA_IV_1));
            MissionGivers.Add(jitaIV_1);

            MissionGiver jitaIV_2 = new MissionGiver("Jita Trade Officer", MISSION_GIVER_ID_JITA_IV_2, 2);
            jitaIV_2.Missions.Add(MissionByID(MISSION_ID_JITA_IV_2));
            MissionGivers.Add(jitaIV_2);
        }

        private static void InitializeLocations()
        {
            Station jitaIV = new Station("Jita IV", LOCATION_ID_STATION_JITA_IV, SECURITY_LEVEL_JITA);
            Shop jitaIVMarket = new Shop("Jita IV Market", SHOP_ID_JITA_IV);
            jitaIV.Market = jitaIVMarket;
            jitaIV.Agents.Add(MissionGiverByID(MISSION_GIVER_ID_JITA_IV_1));
            jitaIV.Agents.Add(MissionGiverByID(MISSION_GIVER_ID_JITA_IV_2));
            CloneBay jitaIVCloneBay = new CloneBay("Jita IV Clone Bay", CLONE_BAY_ID_JITA_IV);
            jitaIV.RespawnPoint = jitaIVCloneBay;

            Station amarrI = new Station("Amarr", LOCATION_ID_STATION_AMARR_I, SECURITY_LEVEL_AMARR);
            Shop amarrIMarket = new Shop("Amarr I Market", SHOP_ID_AMARR_I);
            amarrI.Market = amarrIMarket;
            CloneBay amarrICloneBay = new CloneBay("Amarr I Clone Bay", CLONE_BAY_ID_AMARR_I);
            amarrI.RespawnPoint = amarrICloneBay;

            Location sun = new Location("Sun", LOCATION_ID_SUN);
            sun.AddEnemy(EnemyByID(ENEMYSHIP_ID_CAPSULEER));

            Location asteroidBeltJitaI = new Location("Jita I - Asteroid Belt I", LOCATION_ID_ASTEROID_BELT_JITA_I);
            asteroidBeltJitaI.AddEnemy(EnemyByID(ENEMYSHIP_ID_PIRATE_ONE), 1);

            Location asteroidBeltJitaII = new Location("Jita II - Asteroid Belt II", LOCATION_ID_ASTEROID_BELT_JITA_II);
            asteroidBeltJitaI.AddEnemy(EnemyByID(ENEMYSHIP_ID_PIRATE_ONE), 2);

            Location asteroidBeltAmarrI = new Location("Amarr I - Asteroid Belt I - Amarr I", LOCATION_ID_ASTEROID_BELT_AMARR_I);
            asteroidBeltJitaI.AddEnemy(EnemyByID(ENEMYSHIP_ID_PIRATE_TWO), 1);

            Location asteroidBeltAmarrII = new Location("Amarr II - Asteroid Belt II", LOCATION_ID_ASTEROID_BELT_AMARR_II);
            asteroidBeltJitaI.AddEnemy(EnemyByID(ENEMYSHIP_ID_PIRATE_TWO), 3);

            Gate toAmarr = new Gate("Amarr Gate", LOCATION_ID_GATE_AMARR);
            Gate toJita = new Gate("Jita Gate", LOCATION_ID_GATE_JITA);
            toAmarr.Destination = toJita;
            toJita.Destination = toAmarr;

            toJita.AddEnemy(EnemyByID(ENEMYSHIP_ID_PIRATE_TWO));

            System jita = new System("Jita", SYSTEM_ID_JITA, SECURITY_LEVEL_JITA);
            jita.Locations.Add(sun);
            jita.Locations.Add(asteroidBeltJitaI);
            jita.Locations.Add(asteroidBeltJitaII);
            jita.Locations.Add(jitaIV);
            Systems.Add(jita);

            System amarr = new System("Amarr", SYSTEM_ID_AMARR, SECURITY_LEVEL_AMARR);
            amarr.Locations.Add(sun);
            amarr.Locations.Add(asteroidBeltAmarrI);
            amarr.Locations.Add(asteroidBeltAmarrII);
            amarr.Locations.Add(amarrI);
            Systems.Add(amarr);
        }

        public static Item ItemByID(int id)
        {
            return Items.SingleOrDefault(x => x.ID == id);
        }
        
        public static Weapon WeaponByID(int id)
        {
            return (Weapon)Items.SingleOrDefault(x => x.ID == id);
        }

        public static EnemyShip EnemyByID(int id)
        {
            return Enemies.SingleOrDefault(x => x.ID == id);
        }

        public static PlayerShip PlayerShipByID(int id)
        {
            return PlayerShips.SingleOrDefault(x => x.ID == id);
        }

        public static Mission MissionByID(int id)
        {
            return Missions.SingleOrDefault(x => x.ID == id);
        }

        public static MissionGiver MissionGiverByID(int id)
        {
            return MissionGivers.SingleOrDefault(x => x.ID == id);
        }

    }
}