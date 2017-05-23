using System;
using Engine;

namespace EVETextRPG
{
	public class EVETextRPG
	{
		private static Player _player;

		private static void Main(String[] args)
		{
			Console.Write("Enter your name: ");
			string playerName = Console.ReadLine();
			_player = new Player (playerName, 100, 100, 0, 0);

			bool exit = false;

			while (!exit)
			{
				Console.WriteLine(">");

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
			
		}
	}
}

