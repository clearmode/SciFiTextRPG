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
        public const int ITEM_ID_SMALL_LASER = 0004;
        public const int ITEM_ID_SMALL_ROCKET_LAUNCHER = 0005;

        public const int LOCATION_ID_STATION_DITA_IV = 1000;
        public const int LOCATION_ID_STATION_DMARR_I = 1001;

        public const int LOCATION_ID_ASTEROID_BELT_DITA_I = 2000;
        public const int LOCATION_ID_ASTEROID_BELT_DITA_II = 2001;
        public const int LOCATION_ID_ASTEROID_BELT_DMARR_I = 2002;
        public const int LOCATION_ID_ASTEROID_BELT_DMARR_II = 2003;
        public const int LOCATION_ID_DITA_SUN = 2004;
        public const int LOCATION_ID_DMARR_SUN = 2005;

        public const int LOCATION_ID_GATE_DMARR = 3000;
        public const int LOCATION_ID_GATE_DITA = 3001;

        public const int SYSTEM_ID_DITA = 4000;
        public const int SYSTEM_ID_DMARR = 4001;

        public const int PLAYERSHIP_ID_FRYGET = 5000;
        public const int PLAYERSHIP_ID_INTERCEPTOR = 5001;

        public const int ENEMYSHIP_ID_PIRATE_ONE = 6000;
        public const int ENEMYSHIP_ID_PIRATE_TWO = 6001;
        public const int ENEMYSHIP_ID_CAPSULEER = 6002;

        public const int SHOP_ID_DITA_IV = 7000;
        public const int SHOP_ID_DMARR_I = 7001;

        public const int MISSION_ID_DITA_IV_1 = 9000;
        public const int MISSION_ID_DITA_IV_2 = 9001;
        public const int MISSION_ID_DITA_IV_3 = 9002;
        public const int MISSION_ID_DITA_IV_4 = 9003;

        public const int MISSION_ID_DMARR_I_1 = 9100;

        public const int MISSION_GIVER_ID_DITA_IV_1 = 10000;
        public const int MISSION_GIVER_ID_DITA_IV_2 = 10001;
        public const int MISSION_GIVER_ID_DMARR_I_1 = 10002;

        public const int SECURITY_LEVEL_DITA = 10;
        public const int SECURITY_LEVEL_DMARR = 10;

		static World()
        {
            InitializeItems();
            InitializeWeapons();
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
        }

        private static void InitializeWeapons()
        {
            Weapon smallLaserI = new Weapon("Small Laser", "Small Lasers", ITEM_ID_SMALL_LASER, 1000, 10, 100, .8);
            Items.Add(smallLaserI);

            Weapon smallRocketLauncher = new Weapon("Small Rocket Launcher", "Small Rocket Launchers", ITEM_ID_SMALL_ROCKET_LAUNCHER, 1000, 10, 75, 1);
            Items.Add(smallRocketLauncher);
        }

        private static void InitializePlayerShips()
        {

            PlayerShip fryget = new PlayerShip("Fryget", PLAYERSHIP_ID_FRYGET, 500, 500, 3, 500);
            PlayerShips.Add(fryget);

            PlayerShip interceptor = new PlayerShip("Executioner", PLAYERSHIP_ID_INTERCEPTOR, 1000, 1000, 4, 1000);
            PlayerShips.Add(interceptor);

        }

        private static void InitializeEnemies()
        {
            EnemyShip pirate1 = new EnemyShip("Pirate One", ENEMYSHIP_ID_PIRATE_ONE, 500, 500, 2, 10, 1000);
            pirate1.EquipWeapon(WeaponByID(ITEM_ID_SMALL_ROCKET_LAUNCHER), 0);
            pirate1.EquipWeapon(WeaponByID(ITEM_ID_SMALL_ROCKET_LAUNCHER), 1);
            Enemies.Add(pirate1);

            EnemyShip pirate2 = new EnemyShip("Pirate Two", ENEMYSHIP_ID_PIRATE_TWO, 500, 500, 2, 10, 1000);
            pirate1.EquipWeapon(WeaponByID(ITEM_ID_SMALL_LASER), 0);
            pirate1.EquipWeapon(WeaponByID(ITEM_ID_SMALL_LASER), 1);
            Enemies.Add(pirate2);

            EnemyShip capsuleer = new EnemyShip("Hostile Clone", ENEMYSHIP_ID_CAPSULEER, 1000, 1000, 4, 50, 10000);
            capsuleer.EquipWeapon(WeaponByID(ITEM_ID_SMALL_ROCKET_LAUNCHER), 0);
            capsuleer.EquipWeapon(WeaponByID(ITEM_ID_SMALL_ROCKET_LAUNCHER), 1);
            capsuleer.EquipWeapon(WeaponByID(ITEM_ID_SMALL_LASER), 2);
            capsuleer.EquipWeapon(WeaponByID(ITEM_ID_SMALL_LASER), 3);
            Enemies.Add(capsuleer);
        }

        private static void InitializeMissions()
        {
            Mission ditaIV_1 = new Mission("Clear Asteroid Belt I", MISSION_ID_DITA_IV_1, 
                "Our miners are unable to mine due to pirates in Asteroid Belt I.\n Please go clear them out.", 100, 5000);
            Missions.Add(ditaIV_1);

            Mission ditaIV_2 = new Mission("Clear Asteroid Belt II", MISSION_ID_DITA_IV_2,
                "Our miners are unable to mine due to pirates in Asteroid Belt II.\n Please go clear them out.", 150, 8000);
            Missions.Add(ditaIV_2);
        }

        private static void InitializeMissionGivers()
        {
            MissionGiver ditaIV_1 = new MissionGiver("Dita Military Officer", MISSION_GIVER_ID_DITA_IV_1, 1);
            ditaIV_1.Missions.Add(MissionByID(MISSION_ID_DITA_IV_1));
            MissionGivers.Add(ditaIV_1);

            MissionGiver ditaIV_2 = new MissionGiver("Dita Trade Officer", MISSION_GIVER_ID_DITA_IV_2, 2);
            ditaIV_2.Missions.Add(MissionByID(MISSION_ID_DITA_IV_2));
            MissionGivers.Add(ditaIV_2);
        }

        private static void InitializeLocations()
        {
            Station stationDitaIV = new Station("Dita IV - Moon 4 - Faldari Navy Assembly Plant", LOCATION_ID_STATION_DITA_IV, SECURITY_LEVEL_DITA, true);
            Shop ditaIVMarket = new Shop("Dita IV Market", SHOP_ID_DITA_IV);
            stationDitaIV.Market = ditaIVMarket;
            stationDitaIV.Agents.Add(MissionGiverByID(MISSION_GIVER_ID_DITA_IV_1));
            stationDitaIV.Agents.Add(MissionGiverByID(MISSION_GIVER_ID_DITA_IV_2));


            Station stationDmarrI = new Station("Dmarr VIII (Oris) - Emperor Family Academy", LOCATION_ID_STATION_DMARR_I, SECURITY_LEVEL_DMARR, true);
            Shop dmarrIMarket = new Shop("Dmarr I Market", SHOP_ID_DMARR_I);
            stationDmarrI.Market = dmarrIMarket;

            Location sunDita = new Location("Sun", LOCATION_ID_DITA_SUN);
            sunDita.AddEnemy(EnemyByID(ENEMYSHIP_ID_CAPSULEER));

            Location sunDmarr = new Location("Sun", LOCATION_ID_DMARR_SUN);
            sunDmarr.AddEnemy(EnemyByID(ENEMYSHIP_ID_CAPSULEER));

            Location asteroidBeltDitaI = new Location("Dita I - Asteroid Belt I", LOCATION_ID_ASTEROID_BELT_DITA_I);
            asteroidBeltDitaI.AddEnemy(EnemyByID(ENEMYSHIP_ID_PIRATE_ONE), 1);

            Location asteroidBeltDitaII = new Location("Dita II - Asteroid Belt II", LOCATION_ID_ASTEROID_BELT_DITA_II);
            asteroidBeltDitaI.AddEnemy(EnemyByID(ENEMYSHIP_ID_PIRATE_ONE), 2);

            Location asteroidBeltDmarrI = new Location("Dmarr I - Asteroid Belt I", LOCATION_ID_ASTEROID_BELT_DMARR_I);
            asteroidBeltDitaI.AddEnemy(EnemyByID(ENEMYSHIP_ID_PIRATE_TWO), 1);

            Location asteroidBeltDmarrII = new Location("Dmarr II - Asteroid Belt II", LOCATION_ID_ASTEROID_BELT_DMARR_II);
            asteroidBeltDitaI.AddEnemy(EnemyByID(ENEMYSHIP_ID_PIRATE_TWO), 3);

            Gate toDmarr = new Gate("Stargate (Dmarr)", LOCATION_ID_GATE_DMARR);
            Gate toDita = new Gate("Stargate (Dita)", LOCATION_ID_GATE_DITA);
            toDmarr.Destination = toDita;
            toDita.Destination = toDmarr;

            toDita.AddEnemy(EnemyByID(ENEMYSHIP_ID_PIRATE_TWO));

            System dita = new System("Dita", SYSTEM_ID_DITA, SECURITY_LEVEL_DITA);
            dita.Locations.Add(sunDita);
            dita.Locations.Add(asteroidBeltDitaI);
            dita.Locations.Add(asteroidBeltDitaII);
            dita.Locations.Add(stationDitaIV);
            Systems.Add(dita);

            System dmarr = new System("Dmarr", SYSTEM_ID_DMARR, SECURITY_LEVEL_DMARR);
            dmarr.Locations.Add(sunDmarr);
            dmarr.Locations.Add(asteroidBeltDmarrI);
            dmarr.Locations.Add(asteroidBeltDmarrII);
            dmarr.Locations.Add(stationDmarrI);
            Systems.Add(dmarr);
        }

        public static Item ItemByID(int id)
        {
            return Items.SingleOrDefault(x => x.ID == id);
        }

        public static Location LocationByID(int id)
        {
            System system = SystemByLocationID(id);

            return system.Locations.SingleOrDefault(x => x.ID == id);
        }

        public static System SystemByLocationID(int id)
        {
            return Systems.SingleOrDefault(x => x.Locations.SingleOrDefault(y => y.ID == id) != null);
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