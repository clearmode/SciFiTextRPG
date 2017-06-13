using System;
using System.Linq;

using Engine;

namespace EVETextRPG
{
	public class EVETextRPG
	{
		private static Player _player;
        private static bool ExitGame { get; set; }

		private static void Main(String[] args)
		{
			Console.Write("Enter your name: ");
			string playerName = Console.ReadLine();
            Console.WriteLine("Hello " + playerName + ", welcome to New Eden. Fly safe.");
            Console.WriteLine();
            _player = new Player(playerName, 100, 100, 0, 0);
            PlayerMoved(null, EventArgs.Empty);

            _player.PlayerMoved += PlayerMoved;
            _player.PlayerDied += PlayerDied;
            _player.OnMessage += WriteMessage;


			while (!ExitGame)
			{
				Console.Write(">");

				string input = Console.ReadLine()?.ToLower();

				if (input != null && input != "exit")
				{
					ParseInput(input);
				}
			}

			//TODO save game
		}

		private static void ParseInput(string input)
		{
            int firstSpacePosition = input.IndexOf(' ');
            string command;
            string args;

            if(firstSpacePosition != -1)
            {
			    command = input.Substring(0, firstSpacePosition);
                args = input.Substring(firstSpacePosition+1);
            }
            else
            {
                command = input;
                args = "";
            }

            switch(command)
            {
                case "quit":
                    ExitGame = true;
                    break;
                case "warp":
                    if (_player.CurrentSystem.Locations.Count >= Int32.Parse(args))
                    {
                        _player.MoveTo(_player.CurrentSystem.Locations.ElementAt(Int32.Parse(args)));
                    }
                    else
                    {
                        Console.WriteLine("Error: Warp not found.");
                    }
                    break;
            }
		}

        private static void PlayerMoved(object sender, EventArgs e)
        {
            PrintSystem();

            if (_player.CurrentLocation is Station)
            {
                Console.WriteLine("You are docked in " + _player.CurrentLocation.Name);
            }
            else if (_player.CurrentLocation is Gate)
            {
                Console.WriteLine("You are at the Gate to " + ((Gate)_player.CurrentLocation).Destination);
            }
            else if (_player.CurrentEnemies.Any())
            {
                if (_player.CurrentEnemies.Count > 1)
                {
                    Console.WriteLine("As you leave warp, you spot enemy ships.");
                }
                else
                {
                    Console.WriteLine("As you leave warp, you spot an enemy ship.");
                }

                PrintEnemies();
            }
            else
            {

            }
        }

        private static void PlayerDied(object sender, EventArgs e)
        {
            Console.WriteLine("Your ship was destroyed.");
            Console.WriteLine("Transferring you to a new clone.");
            Console.WriteLine();
        }

        private static void PrintEnemies()
        {
            foreach (EnemyShip enemy in _player.CurrentEnemies)
            {
                Console.WriteLine(enemy);
            }
            
            Console.WriteLine();
        }

        private static void PrintWarps()
        {
            int count = 1;
            foreach (Location warp in _player.CurrentSystem.Locations)
            {
                if (!warp.Equals(_player.CurrentLocation))
                {
                    Console.WriteLine("Warp " + count + ": " + warp);
                    count++;
                }
            }
        }

        private static void PrintSystem()
        {
            Console.WriteLine("Current System: " + _player.CurrentSystem);
        }

        private static void WriteMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Message);

            if (e.AddExtraNewLine)
            {
                Console.WriteLine();
            }
        }
    }
}

