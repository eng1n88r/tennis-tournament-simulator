namespace TennisTournament.BusinessEntities
{
	/// <summary>
	/// Represents the game master of the tournament.
	/// </summary>
	/// <seealso cref="TennisTournament.BusinessEntities.Referee" />
	public class GameMaster : Referee
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="GameMaster"/> class.
		/// </summary>
		public GameMaster()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GameMaster"/> class.
		/// </summary>
		/// <param name="referee">The referee.</param>
		public GameMaster(Referee referee)
		{
			this.Country = referee.Country;
			this.DateOfBirth = referee.DateOfBirth;
			this.FirstName = referee.FirstName;
			this.Gender = referee.Gender;
			this.Id = referee.Id;
			this.LastName = referee.LastName;
			this.LicenseGot = referee.LicenseGot;
			this.LicenseRenewal = referee.LicenseRenewal;
			this.MiddleName = referee.MiddleName;
			this.ShortCountry = referee.ShortCountry;
		}

		#endregion Constructors
	}
}
