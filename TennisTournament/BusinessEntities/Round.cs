namespace TennisTournament.BusinessEntities
{
	#region Usings

	using System.Collections.Generic;

	#endregion Usings

	/// <summary>
	/// Represent tournament round with several games in it.
	/// </summary>
	public class Round
	{
		/// <summary>
		/// Gets or sets the round number.
		/// </summary>
		/// <value>
		/// The round number.
		/// </value>
		public int RoundNumber { get; set; }

		/// <summary>
		/// Gets or sets the games.
		/// </summary>
		/// <value>
		/// The games.
		/// </value>
		public List<Game> Games { get; set; }

		public Round(int number, List<Game> games)
		{
			this.RoundNumber = number;
			this.Games = games;
		}

		public void StartRound()
		{
			this.Games.ForEach(g => g.PlayGame());
		}
	}
}
