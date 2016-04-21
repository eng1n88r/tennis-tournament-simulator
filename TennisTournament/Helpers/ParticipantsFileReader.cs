namespace TennisTournament.Helpers
{
	#region Usings

	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;

	using Enumerations;
	using BusinessEntities;

	#endregion Usings

	/// <summary>
	/// Represents helper class to read input data files.
	/// </summary>
	public static class ParticipantsFileReader
	{
		/// <summary>
		/// Parses the players file.
		/// </summary>
		/// <param name="malePlayersFile">The male players file.</param>
		/// <param name="femalePlayersFile">The female players file.</param>
		/// <param name="limit">The limit.</param>
		/// <param name="type">The type.</param>
		/// <returns>Returns collection of players.</returns>
		public static IList<Player> ParsePlayersFile(string malePlayersFile, string femalePlayersFile, int limit, GameType type)
		{
			List<string> maleFileContent = null;
			List<string> femaleFileContent = null;
			List <Player> players = new List<Player>();

			switch (type)
			{
				case GameType.SingleMale:
				case GameType.DoubleMale:
					maleFileContent = File.ReadAllLines(malePlayersFile).ToList();
					PopulatePlayers(limit, maleFileContent, players, Gender.Male);
					break;
				case GameType.DoubleFemale:
				case GameType.SingleFemale:
					femaleFileContent = File.ReadAllLines(femalePlayersFile).ToList();
					PopulatePlayers(limit, femaleFileContent, players, Gender.Female);
					break;
				case GameType.MixDouble:
					maleFileContent = File.ReadAllLines(malePlayersFile).ToList();
					femaleFileContent = File.ReadAllLines(femalePlayersFile).ToList();
					PopulatePlayers(limit, maleFileContent, players, Gender.Male);
					PopulatePlayers(limit, femaleFileContent, players, Gender.Female);
					break;
			}

			return players;
		}

		/// <summary>
		/// Populates the players.
		/// </summary>
		/// <param name="limit">The limit.</param>
		/// <param name="fileContent">Content of the file.</param>
		/// <param name="players">The players.</param>
		/// <param name="gender">The gender.</param>
		private static void PopulatePlayers(int limit, List<string> fileContent, List<Player> players, Gender gender)
		{
			foreach (var line in fileContent.Take(limit))
			{
				string[] parsedLine = line.Split(new char[] { '|' });

				var player = new Player();

				player.Id = Int32.Parse(parsedLine[0]);
				player.FirstName = parsedLine[1];
				player.MiddleName = parsedLine[2];
				player.LastName = parsedLine[3];
				player.DateOfBirth = DateTime.Parse(parsedLine[4]);
				player.Country = parsedLine[5];
				player.ShortCountry = parsedLine[6];
				player.Gender = gender;

				players.Add(player);
			}
		}

		/// <summary>
		/// Parses the referee file.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		/// <param name="limit">The limit.</param>
		/// <returns>Returns collection of referees.</returns>
		public static IList<Referee> ParseRefereeFile(string filePath, int limit)
		{
			List<Referee> referees = new List<Referee>();
			List<string> fileContent = File.ReadAllLines(filePath).ToList();

			foreach (var line in fileContent.Take(limit))
			{
				string[] parsedLine = line.Split(new char[] { '|' });

				var referee = new Referee();

				referee.Id = Int32.Parse(parsedLine[0]);
				referee.FirstName = parsedLine[1];
				referee.MiddleName = parsedLine[2];
				referee.LastName = parsedLine[3];
				referee.DateOfBirth = DateTime.Parse(parsedLine[4]);
				referee.Country = parsedLine[5];
				referee.ShortCountry = parsedLine[6];
				referee.LicenseGot = DateTime.Parse(parsedLine[7]);
				referee.LicenseRenewal = DateTime.Parse(parsedLine[8]);

				referees.Add(referee);
			}

			return referees;
		}
	}
}
