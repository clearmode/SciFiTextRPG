using System;
using Engine;

namespace EVETextRPG
{
	public class EVETextRPG
	{
		private static Player _player;
        public bool ExitGame { private get; private set; }

		private static void Main(String[] args)
		{
			Console.Write("Enter your name: ");
			string playerName = Console.ReadLine();
			_player = new Player (playerName, 100, 100, 0, 0);

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

            if(firstSpacePosition != -1)
            {
			    command = input.Substring(0, firstSpacePosition);
            }
            else
            {
                command = input;
            }

            switch(command)
            {
                case "quit":
                    ExitGame = true;
                    break;
            }
		}
	}
}

