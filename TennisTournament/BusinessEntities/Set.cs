namespace TennisTournament.BusinessEntities
{
	#region Usings

	using System;

	#endregion Usings

	/// <summary>
	/// Represents one set from the game.
	/// </summary>
	public class Set
	{
		#region Constants

		/// <summary>
		/// The maximum points per set.
		/// </summary>
		private const int MaxPointsPerSet = 6;

		/// <summary>
		/// The random coin.
		/// </summary>
		private static Random coin = new Random();

		#endregion Constants

		#region Private Properties

		/// <summary>
		/// Gets or sets the team1.
		/// </summary>
		/// <value>
		/// The team1.
		/// </value>
		private Team Team1 { get; set; }

		/// <summary>
		/// Gets or sets the team2.
		/// </summary>
		/// <value>
		/// The team2.
		/// </value>
		private Team Team2 { get; set; }

		#endregion Private Properties

		#region Public Properties

		/// <summary>
		/// Gets or sets the winner.
		/// </summary>
		/// <value>
		/// The winner.
		/// </value>
		public Team Winner { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Set"/> is completed.
		/// </summary>
		/// <value>
		///   <c>true</c> if completed; otherwise, <c>false</c>.
		/// </value>
		public bool Completed { get; set; }

		#endregion Public Properties

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="Set"/> class.
		/// </summary>
		/// <param name="team1">The team1.</param>
		/// <param name="team2">The team2.</param>
		public Set(Team team1, Team team2)
		{
			Completed = false;

			Team1 = team1;
			Team2 = team2;
		}

		#endregion Constructor

		#region Public Methods

		/// <summary>
		/// Plays this set.
		/// </summary>
		public void Play()
		{
			ResetTeamsPoints();

			while (Team1.Points < MaxPointsPerSet && Team2.Points < MaxPointsPerSet)
			{
				if (coin.Next() % 2 == 0)
				{
					Team1.Points++;
				}
				else
				{
					Team2.Points++;
				}
			}

			SetWinner();
		}

		#endregion Public Methods

		#region Internal Implementation

		/// <summary>
		/// Sets the winner of the set.
		/// </summary>
		private void SetWinner()
		{
			if (Team1.Points == MaxPointsPerSet)
			{
				Winner = Team1;
			}
			else
			{
				Winner = Team2;
			}

			Completed = true;
		}

		/// <summary>
		/// Resets the teams points.
		/// </summary>
		private void ResetTeamsPoints()
		{
			Team1.Points = 0;
			Team2.Points = 0;
		}

		#endregion Internal Implementation
	}
}
