namespace TennisTournament
{
	#region Usings

	using System;
	using System.Collections.Generic;
	using System.Linq;

	using BusinessEntities;
	using Helpers;
	using System.IO;
	using Enumerations;
	#endregion Usings

	class Program
	{
		static void Main(string[] args)
		{
			string malePlayersFile = @"data/MalePlayer.txt";
			string femalePlayersFile = @"data/FemalePlayer.txt";
			string refereesFile = @"data/refs.txt";

			var type = (GameType)SelectType();

			Tournament tournament = new Tournament("US OPEN", 2016, DateTime.Now, DateTime.Now.AddMonths(1), type);

			int participantLimit = SelectPlayersCount();

			List<Player> players = 
				ParticipantsFileReader.ParsePlayersFile(malePlayersFile, femalePlayersFile, participantLimit, type).ToList();
			List<Referee> referees =
				ParticipantsFileReader.ParseRefereeFile(refereesFile, participantLimit).ToList();
			
			players.ForEach(player => tournament.AddPlayer(player));

			referees.ForEach(referee => tournament.AddReferee(referee));

			GameMaster gameMaster = new GameMaster(referees.First());

			tournament.AddGameMaster(gameMaster);

			tournament.StartTheTournament();
			tournament.ShowTheWinner();
		}

		/// <summary>
		/// Selects the type.
		/// </summary>
		/// <returns>Returns the type of the tournament selected by user.</returns>
		static public int SelectType()
		{
			Console.WriteLine("Select tournament type:");
			Console.WriteLine("1. Single Female");
			Console.WriteLine("2. Single Male:");
			Console.WriteLine("3. Double Female");
			Console.WriteLine("4. Double Male");
			Console.WriteLine("5. Mix Double");

			return Convert.ToInt32(Console.ReadLine());
		}

		/// <summary>
		/// Selects the players count.
		/// </summary>
		/// <returns>Returns number of players for the tournament selected by user.</returns>
		static public int SelectPlayersCount()
		{
			int playersCount = 0;

			Console.WriteLine("Select players count:");
			Console.WriteLine("1. 8");
			Console.WriteLine("2. 16");
			Console.WriteLine("3. 32");
			Console.WriteLine("4. 64");

			switch(Convert.ToInt32(Console.ReadLine()))
			{
				case 1:
					playersCount = 8;
					break;
				case 2:
					playersCount = 16;
					break;
				case 3:
					playersCount = 32;
					break;
				case 4:
					playersCount = 64;
					break;
			}

			return playersCount;
		}

	}
}
