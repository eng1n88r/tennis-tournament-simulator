namespace TennisTournament.BusinessEntities
{
	#region Usings

	using System;
	using System.Linq;
	using System.Collections.Generic;

	using Enumerations;

	#endregion Usings

	/// <summary>
	/// Represents tournament game class.
	/// </summary>
	public class Game
	{
		#region Constants

		/// <summary>
		/// The max female number of sets.
		/// </summary>
		private const int FemaleNumberOfSets = 3;

		/// <summary>
		/// The maxc male and mix number of sets.
		/// </summary>
		private const int MaleAndMixNumberOfSets = 5;

		#endregion Constants

		#region Private Properties

		/// <summary>
		/// Gets or sets the winner.
		/// </summary>
		/// <value>
		/// The winner.
		/// </value>
		private Team Winner { get; set; }

		/// <summary>
		/// Gets or sets the looser.
		/// </summary>
		/// <value>
		/// The looser.
		/// </value>
		private Team Looser { get; set; }

		#endregion Private PropertiesS

		#region Public Properties

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		public GameType Type { get; set; }

		/// <summary>
		/// Gets or sets the team1.
		/// </summary>
		/// <value>
		/// The team1.
		/// </value>
		public Team Team1 { get; set; }

		/// <summary>
		/// Gets or sets the team2.
		/// </summary>
		/// <value>
		/// The team2.
		/// </value>
		public Team Team2 { get; set; }

		/// <summary>
		/// Gets or sets the sets.
		/// </summary>
		/// <value>
		/// The sets.
		/// </value>
		public List<Set> Sets { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Game"/> is completed.
		/// </summary>
		/// <value>
		///   <c>true</c> if completed; otherwise, <c>false</c>.
		/// </value>
		public bool Completed { get; set; }

		/// <summary>
		/// Gets or sets the referee.
		/// </summary>
		/// <value>
		/// The referee.
		/// </value>
		public Referee Referee { get; set; }

		#endregion Public Properties

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Game"/> class.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="team1">The team1.</param>
		/// <param name="team2">The team2.</param>
		/// <param name="referee">The referee.</param>
		/// <exception cref="ArgumentException">Teams are not valid! Please, rearrange players and try again.</exception>
		public Game(GameType type, Team team1, Team team2, Referee referee)
		{
			Type = type;
			Team1 = team1;
			Team2 = team2;
			Referee = referee;

			bool teamsAreValid = ValidateTeamPlayers();

			if (!teamsAreValid)
			{
				throw new ArgumentException("Teams are not valid! Please, rearrange players and try again.");
			}
		}

		#endregion Constructors

		#region Public Methods

		/// <summary>
		/// Gets the number of played sets.
		/// </summary>
		/// <returns>Returns number of played sets in the game.</returns>
		public int GetNumberOfPlayedSets()
		{
			return Sets.Count;
		}

		/// <summary>
		/// Gets the winner.
		/// </summary>
		/// <returns>Returns the winner of the game.</returns>
		public Team GetTheWinner()
		{
			return Winner;
		}

		/// <summary>
		/// Gets the looser.
		/// </summary>
		/// <returns>Returns the looser of the game.</returns>
		public Team GetTheLooser()
		{
			return Looser;
		}

		/// <summary>
		/// Plays the game.
		/// </summary>
		public void PlayGame()
		{
			switch (Type)
			{
				case GameType.SingleFemale:
				case GameType.DoubleFemale:
					CreateGameSets(FemaleNumberOfSets);
					break;
				case GameType.SingleMale:
				case GameType.DoubleMale:
				case GameType.MixDouble:
					CreateGameSets(MaleAndMixNumberOfSets);
					break;
			}

			this.Sets.ForEach(set => set.Play());

			CalculateTheWinner();
		}

		#endregion Public Methods

		#region Internal Implementation

		/// <summary>
		/// Calculates the winner.
		/// </summary>
		private void CalculateTheWinner()
		{
			if (this.Sets.All(s=> s.Completed))
			{
				var team1WinsCount = this.Sets.Count(s => s.Winner == Team1);
				var team2WinsCount = this.Sets.Count(s => s.Winner == Team2);

				if (team1WinsCount > team2WinsCount)
				{
					this.Winner = Team1;
					this.Looser = Team2;
				}
				else
				{
					this.Winner = Team2;
					this.Looser = Team1;
				}
			}
		}

		/// <summary>
		/// Creates the game sets.
		/// </summary>
		/// <param name="setCount">The set count.</param>
		private void CreateGameSets(int setCount)
		{
			Sets = new List<Set>();

			for (int i = 0; i < setCount; i++)
			{
				Set set = new Set(Team1, Team2);

				Sets.Add(set);
			}

			Completed = true;
		}

		/// <summary>
		/// Validates the team players.
		/// </summary>
		/// <returns></returns>
		private bool ValidateTeamPlayers()
		{
			bool result = false;

			switch (Type)
			{
				case GameType.SingleFemale:
					if (Team1.Players.Count == 1 && Team1.Players.All(p => p.Gender == Gender.Female) &&
						Team2.Players.Count == 1 && Team2.Players.All(p => p.Gender == Gender.Female))
					{
						result = true;
					}
					break;
				case GameType.SingleMale:
					if (Team1.Players.Count == 1 && Team1.Players.All(p => p.Gender == Gender.Male) &&
						Team2.Players.Count == 1 && Team2.Players.All(p => p.Gender == Gender.Male))
					{
						result = true;
					}
					break;
				case GameType.DoubleFemale:
					if (Team1.Players.Count == 2 && Team1.Players.All(p => p.Gender == Gender.Female) &&
						Team2.Players.Count == 2 && Team2.Players.All(p => p.Gender == Gender.Female))
					{
						result = true;
					}
					break;
				case GameType.DoubleMale:
					if (Team1.Players.Count == 2 && Team1.Players.All(p => p.Gender == Gender.Male) &&
						Team2.Players.Count == 2 && Team2.Players.All(p => p.Gender == Gender.Male))
					{
						result = true;
					}
					break;
				case GameType.MixDouble:
					if (Team1.Players.Count == 2 && Team1.Players.Exists(p => p.Gender == Gender.Male) && Team1.Players.Exists(p => p.Gender == Gender.Female) &&
						Team2.Players.Count == 2 && Team2.Players.Exists(p => p.Gender == Gender.Male) && Team2.Players.Exists(p => p.Gender == Gender.Female))
					{
						result = true;
					}
					break;
			}

			return result;
		}

		#endregion Internal Implementation
	}
}
