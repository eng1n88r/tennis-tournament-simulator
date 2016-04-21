namespace TennisTournament.BusinessEntities
{
	#region Usings

	using System;

	using Enumerations;
	
	#endregion Usings

	/// <summary>
	/// Represents basic class for Tournament participant.
	/// </summary>
	public class Participant
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the first name.
		/// </summary>
		/// <value>
		/// The first name.
		/// </value>
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the name of the middle.
		/// </summary>
		/// <value>
		/// The name of the middle.
		/// </value>
		public string MiddleName { get; set; }

		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		/// <value>
		/// The last name.
		/// </value>
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the date of birth.
		/// </summary>
		/// <value>
		/// The date of birth.
		/// </value>
		public DateTime DateOfBirth { get; set; }

		/// <summary>
		/// Gets or sets the gender.
		/// </summary>
		/// <value>
		/// The gender.
		/// </value>
		public Gender Gender { get; set; }

		/// <summary>
		/// Gets or sets the country.
		/// </summary>
		/// <value>
		/// The country.
		/// </value>
		public string Country { get; set; }

		/// <summary>
		/// Gets or sets the short country name.
		/// </summary>
		/// <value>
		/// The short country name.
		/// </value>
		public string ShortCountry { get; set; }

		#endregion Public Properties
	}
}
