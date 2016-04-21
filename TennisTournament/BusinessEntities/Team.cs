namespace TennisTournament.BusinessEntities
{
	#region Usings

	using System.Collections.Generic;

	#endregion Usings

	/// <summary>
	/// Represents team class that could contain from 1 to multiple players.
	/// </summary>
	public class Team
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets the players.
		/// </summary>
		/// <value>
		/// The players.
		/// </value>
		public List<Player> Players { get; set; }

		/// <summary>
		/// Gets or sets the points.
		/// </summary>
		/// <value>
		/// The points.
		/// </value>
		public int Points { get; set; }

		#endregion Public Properties
	}
}
