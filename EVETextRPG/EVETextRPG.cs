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
                    {
                        bool choiceWasInt = Int32.TryParse(args, out int choice);
                        choice--;

                        if (choiceWasInt)
                        {
                            if (_player.CurrentSystem.Locations.Count >= choice)
                            {
                                Location warp = _player.WarpableLocations.ElementAt(choice);

                                Console.WriteLine();

                                if (_player.CurrentStation != null)
                                {
                                    Console.WriteLine("You undock and enter warp to " + warp);
                                }
                                else
                                {
                                    Console.WriteLine("You enter warp to " + warp);
                                }

                                Console.WriteLine();
                                _player.MoveTo(warp);
                            }
                            else
                            {
                                Console.WriteLine("Error: Warp not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Warp usage: Warp <Location Number>");
                        }

                        break;
                    }


                case "attack":
                    {
                        bool choiceWasInt = Int32.TryParse(args, out int choice);
                        choice--;

                        if (choiceWasInt)
                        {
                            if (_player.CurrentEnemies.Count >= choice)
                            {
                                _player.AttackEnemy(choice);
                            }
                            else
                            {
                                Console.WriteLine("Error: Enemy not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Attack usage: Attack <Enemy Number>");
                        }

                        break;
                    }
                default:
                    Console.WriteLine("Error: Command not found.");
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
            else
            {
                Console.WriteLine("You are at " + _player.CurrentLocation);
            }

            if (_player.CurrentEnemies.Any())
            {
                Console.WriteLine();
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

            PrintWarps();
        }

        private static void PlayerDied(object sender, EventArgs e)
        {
            Console.WriteLine("Your ship was destroyed.");
            Console.WriteLine("Transferring you to a new clone.");
            Console.WriteLine();
        }

        private static void PrintEnemies()
        {
            int count = 1;
            Console.WriteLine();
            Console.WriteLine("Enemies:");

            foreach (EnemyShip enemy in _player.CurrentEnemies)
            {
                Console.WriteLine(count + ": " + enemy);
                count++;
            }
            
            Console.WriteLine();

            Console.WriteLine("Attack <Enemy Number>");
        }

        private static void PrintWarps()
        {
            int count = 1;

            Console.WriteLine();

            foreach (Location warp in _player.WarpableLocations)
            {
                Console.WriteLine("Warp " + count + ": " + warp);
                count++;
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

