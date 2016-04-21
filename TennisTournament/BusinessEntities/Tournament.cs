namespace TennisTournament.BusinessEntities
{
	#region Usings

	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Enumerations;
	using Helpers;

	#endregion Usings

	/// <summary>
	/// Class represents tennis tournament.
	/// </summary>
	public class Tournament
	{
		#region Constants

		/// <summary>
		/// The players count module.
		/// </summary>
		private const int PlayersCountModule = 8;

		/// <summary>
		/// The players count maximum.
		/// </summary>
		private const int PlayersCountMaximum = 64;

		/// <summary>
		/// The single tournament players count per team.
		/// </summary>
		private const int SingleTournamentPlayersCount = 1;

		/// <summary>
		/// The double tournament players count per team.
		/// </summary>
		private const int DoubleTournamentPlayersCount = 2;

		#endregion Constants

		#region Private Fields

		/// <summary>
		/// The tournament players.
		/// </summary>
		private List<Player> tournamentPlayers = new List<Player>();

		/// <summary>
		/// The tournament referees.
		/// </summary>
		private List<Referee> tournamentReferees = new List<Referee>();

		#endregion Private Fields

		#region Public Properties

		/// <summary>
		/// Gets or sets the name of the tournament.
		/// </summary>
		/// <value>
		/// The name of the tournament.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the year of the tournament.
		/// </summary>
		/// <value>
		/// The year of the tournament.
		/// </value>
		public int Year { get; set; }

		/// <summary>
		/// Gets or sets the start date of the tournament.
		/// </summary>
		/// <value>
		/// The start date of the tournament.
		/// </value>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// Gets or sets the end date of the tournament.
		/// </summary>
		/// <value>
		/// The end date of the tournament.
		/// </value>
		public DateTime EndDate { get; set; }

		/// <summary>
		/// Gets or sets the players of the tournament.
		/// </summary>
		/// <value>
		/// The players of the tournament.
		/// </value>
		public List<Player> Players { get; set; }

		/// <summary>
		/// Gets or sets the referees of the tournament.
		/// </summary>
		/// <value>
		/// The referees of the tournament.
		/// </value>
		public List<Referee> Referees { get; set; }

		/// <summary>
		/// Gets or sets the game master of the tournament.
		/// </summary>
		/// <value>
		/// The game master of the tournament.
		/// </value>
		public GameMaster GameMaster { get; set; }

		/// <summary>
		/// Gets or sets the games of the tournament.
		/// </summary>
		/// <value>
		/// The games of the tournament.
		/// </value>
		public List<Game> Games { get; set; }

		/// <summary>
		/// Gets or sets the type of the tournament games.
		/// </summary>
		/// <value>
		/// The type of the tournament games.
		/// </value>
		public GameType Type { get; set; }

		/// <summary>
		/// Gets or sets the rounds of the tournament.
		/// </summary>
		/// <value>
		/// The rounds of the tournament.
		/// </value>
		public List<Round> Rounds { get; set; }

		#endregion Public Properties

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Tournament" /> class.
		/// </summary>
		/// <param name="name">The name of the tournament.</param>
		/// <param name="year">The year of the tournament.</param>
		/// <param name="startDate">The start date of the tournament.</param>
		/// <param name="endDate">The end date of the tournament.</param>
		/// <param name="type">The type.</param>
		public Tournament(string name, int year, DateTime startDate, DateTime endDate, GameType type)
		{
			this.Name = name;
			this.Year = year;
			this.StartDate = startDate;
			this.EndDate = endDate;
			this.Type = type;
		}

		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// Starts the tournament.
		/// </summary>
		public void StartTheTournament()
		{
			ValidateTheTournament();

			PlayTheTournament();
		}

		/// <summary>
		/// Adds the player.
		/// </summary>
		/// <param name="player">The player.</param>
		public void AddPlayer(Player player)
		{
			AddParticipant(player);
		}

		/// <summary>
		/// Adds the referee.
		/// </summary>
		/// <param name="referee">The referee.</param>
		public void AddReferee(Referee referee)
		{
			AddParticipant(referee);
		}

		/// <summary>
		/// Adds the game master.
		/// </summary>
		/// <param name="gameMaster">The game master.</param>
		public void AddGameMaster(GameMaster gameMaster)
		{
			AddParticipant(gameMaster);
		}

		/// <summary>
		/// Removes the player.
		/// </summary>
		/// <param name="player">The player.</param>
		public void RemovePlayer(Player player)
		{
			RemoveParticipant(player);
		}

		/// <summary>
		/// Removes the referee.
		/// </summary>
		/// <param name="referee">The referee.</param>
		public void RemoveReferee(Referee referee)
		{
			RemoveParticipant(referee);
		}

		/// <summary>
		/// Removes the game master.
		/// </summary>
		/// <param name="gameMaster">The game master.</param>
		public void RemoveGameMaster(GameMaster gameMaster)
		{
			RemoveParticipant(gameMaster);
		}

		/// <summary>
		/// Shows all players.
		/// </summary>
		/// <param name="order">The order.</param>
		public void ShowAllPlayers(SortOrder order)
		{
			if (this.tournamentPlayers != null)
			{
				switch (order)
				{
					case SortOrder.None:
						this.tournamentPlayers.ForEach(p => Console.WriteLine(p));
						break;
					case SortOrder.FirstName:
						this.tournamentPlayers.OrderBy(p => p.FirstName).ToList().ForEach(p => Console.WriteLine(p));
						break;
					case SortOrder.LastName:
						this.tournamentPlayers.OrderBy(p => p.LastName).ToList().ForEach(p => Console.WriteLine(p));
						break;
					default:
						this.tournamentPlayers.OrderBy(p => p.FirstName).ToList().ForEach(p => Console.WriteLine(p));
						break;
				}
			}
		}

		/// <summary>
		/// Shows the winner of the tournament.
		/// </summary>
		public void ShowTheWinner()
		{
			if (this.Players != null)
			{
				if (this.Players.Count == 1 &&
				   (this.Type == GameType.SingleMale ||
				    this.Type == GameType.SingleFemale))
				{
					var winner = this.Players.First();

					Console.WriteLine("The tournament winner is {0} {1} {2}. Congratulations!",
						winner.FirstName,
						winner.MiddleName,
						winner.LastName);
				}
				else if (this.Players.Count == 2 && (this.Type == GameType.DoubleFemale ||
					 this.Type == GameType.DoubleMale || this.Type == GameType.MixDouble))
				{
					var winners = this.Players;

					Console.WriteLine("The tournament winners are {0} {1} {2} and {3} {4} {5}. Congratulations!",
						winners[0].FirstName,
						winners[0].MiddleName,
						winners[0].LastName,
						winners[1].FirstName,
						winners[1].MiddleName,
						winners[1].LastName);
				}
			}
			else
			{
				Console.WriteLine("Tournament was terminated due to computer error. Sorry for inconvenience.");
			}
		}

		/// <summary>
		/// Outputs the message if the Tournament is completed or not.
		/// </summary>
		public void Completed()
		{
			if (Games != null)
			{
				if (Games.Any(g => !g.Completed))
				{
					Console.WriteLine("Tournament is in progress.");
				}
				else
				{
					Console.WriteLine("Tournament is completed.");
				}
			}
		}

		#endregion Public Methods

		#region Internal Implementation

		/// <summary>
		/// Plays the tournament.
		/// </summary>
		private void PlayTheTournament()
		{
			this.Rounds = new List<Round>();

			switch (this.Type)
			{
				case GameType.SingleFemale:
				case GameType.SingleMale:
					PlayRounds(2);
					break;
				case GameType.DoubleFemale:
				case GameType.DoubleMale:
				case GameType.MixDouble:
					PlayRounds(4);
					break;
			}
		}

		/// <summary>
		/// Adds the participant.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="participant">The participant.</param>
		private void AddParticipant<T>(T participant)
		{
			if (participant != null)
			{
				if (participant is Player)
				{
					if (Players == null)
					{
						this.Players = new List<Player>();
					}

					var player = participant as Player;

					this.Players.Add(player);
					this.tournamentPlayers.Add(player);
				}
				else if (participant is GameMaster)
				{
					GameMaster = participant as GameMaster;
				}
				else if (participant is Referee)
				{
					if (Referees == null)
					{
						this.Referees = new List<Referee>();
					}

					var referee = participant as Referee;

					this.Referees.Add(referee);
					this.tournamentReferees.Add(referee);
				}
			}
		}

		/// <summary>
		/// Removes the participant.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="participant">The participant.</param>
		private void RemoveParticipant<T>(T participant)
		{
			if (participant != null)
			{
				if (participant is Player)
				{
					var player = participant as Player;

					if (Players != null && Players.Contains(player))
					{
						Players.Remove(player);
					}
				}
				else if (participant is Referee)
				{
					var referee = participant as Referee;

					if (Referees != null && Referees.Contains(referee))
					{
						Referees.Remove(referee);
					}
				}
				else if (participant is GameMaster)
				{
					GameMaster = null;
				}
			}
		}

		/// <summary>
		/// Plays the rounds.
		/// </summary>
		/// <param name="playersPerGame">The players per game.</param>
		private void PlayRounds(int playersPerGame)
		{
			var roundCount = 0;

			roundCount = (int)Math.Log(this.Players.Count, playersPerGame);

			for (int i = roundCount; i > 0; i--)
			{
				roundCount = (int)Math.Log(this.Players.Count, playersPerGame);

				List<Game> games = new List<Game>();

				var gamesCount = this.Players.Count / playersPerGame;

				for (int y = 0; y < gamesCount; y++)
				{
					games.Add(CreateGameWithPlayers(this.Type));
				}

				var round = new Round(i, games);

				round.StartRound();

				foreach (var game in round.Games)
				{
					var team = game.GetTheWinner();

					team.Players.ForEach(p => this.Players.Add(p));
				}
			}
		}

		/// <summary>
		/// Creates the game with players.
		/// </summary>
		/// <param name="type">The type of the game.</param>
		/// <returns>Returns the game by specified game type.</returns>
		private Game CreateGameWithPlayers(GameType type)
		{
			List<Player> players = null;
			List<Player> opponents = null;

			Team team1 = new Team();
			Team team2 = new Team();

			Game game = null;

			Referee refereee = PickReferee();

			switch (type)
			{
				case GameType.SingleFemale:
					players = this.PickPlayers(SingleTournamentPlayersCount, Gender.Female);
					opponents = this.PickPlayers(SingleTournamentPlayersCount, Gender.Female);
					break;
				case GameType.SingleMale:
					players = this.PickPlayers(SingleTournamentPlayersCount, Gender.Male);
					opponents = this.PickPlayers(SingleTournamentPlayersCount, Gender.Male);
					break;
				case GameType.DoubleFemale:
					players = this.PickPlayers(DoubleTournamentPlayersCount, Gender.Female);
					opponents = this.PickPlayers(DoubleTournamentPlayersCount, Gender.Female);
					break;
				case GameType.DoubleMale:
					players = this.PickPlayers(DoubleTournamentPlayersCount, Gender.Male);
					opponents = this.PickPlayers(DoubleTournamentPlayersCount, Gender.Male);
					break;
				case GameType.MixDouble:
					players = this.PickPlayersForMixedTournament(DoubleTournamentPlayersCount);
					opponents = this.PickPlayersForMixedTournament(DoubleTournamentPlayersCount);
					break;
			}

			team1.Players = players;
			team2.Players = opponents;

			game = new Game(type, team1, team2, refereee);

			return game;
		}

		/// <summary>
		/// Picks the players for mixed tournament by specified count.
		/// </summary>
		/// <param name="count">The count.</param>
		/// <returns>Returns random players for mixed tournament by specified count.</returns>
		private List<Player> PickPlayersForMixedTournament(int count)
		{
			List<Player> players = new List<Player>();

			players.AddRange(this.PickPlayers(1, Gender.Female));
			players.AddRange(this.PickPlayers(1, Gender.Male));

			return players;
		}

		/// <summary>
		/// Picks the specified amount of random players based on gender.
		/// </summary>
		/// <param name="count">The count.</param>
		/// <param name="gender">The gender.</param>
		/// <returns>Returns random players based on count and gender.</returns>
		private List<Player> PickPlayers(int count, Gender gender)
		{
			List<Player> players = null;

			do
			{
				players = this.Players.PickRandom(count).ToList();
			}
			while (players.Count != count && players.All(p => p.Gender == gender));

			players.ForEach(p => this.Players.Remove(p));

			return players;
		}

		/// <summary>
		/// Picks the referee.
		/// </summary>
		/// <returns>Returns random referee.</returns>
		private Referee PickReferee()
		{
			return this.Referees.PickRandom(1).FirstOrDefault();
		}

		/// <summary>
		/// Validates the tournament.
		/// </summary>
		private void ValidateTheTournament()
		{
			if (!this.ValidateGameMasterExists())
			{
				Console.WriteLine("Please, set the Game Master.");
			}

			if (!this.ValidateRefereeExists())
			{
				Console.WriteLine("Please, add at least one Referee.");
			}

			if (!this.ValidateTournamentSize())
			{
				Console.WriteLine("Please, verify Players amount. Available tournament sized are: 8, 16, 32, 64");
			}
		}

		/// <summary>
		/// Validates the game master exists.
		/// </summary>
		/// <returns>Returns true if game master is set, otherwise false.</returns>
		private bool ValidateGameMasterExists()
		{
			if (GameMaster == null)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Validates the referee exists.
		/// </summary>
		/// <returns>Returns true if at least one referee is set, otherwise false.</returns>
		private bool ValidateRefereeExists()
		{
			if (this.Referees != null && this.Referees.Count > 0)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Validates the size of the tournament.
		/// </summary>
		/// <returns>Returns true if players count matches the tournament requirements, otherwise false.</returns>
		private bool ValidateTournamentSize()
		{
			if (this.Players.Count % PlayersCountModule == 0 &&
				this.Players.Count <= PlayersCountMaximum &&
				(this.Type == GameType.SingleFemale ||
				 this.Type == GameType.SingleMale))
			{
				return true;
			}
			else if (this.Players.Count % PlayersCountModule == 0 &&
					 this.Players.Count <= PlayersCountMaximum * 2 &&
					 (this.Type == GameType.DoubleFemale ||
					  this.Type == GameType.DoubleMale ||
					  this.Type == GameType.MixDouble))
			{
				return true;
			}

			return false;
		}

		#endregion Internal Implementation
	}
}
