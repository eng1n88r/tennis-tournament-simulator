namespace TennisTournament.BusinessEntities
{
	#region Usings

	using System;

	#endregion Usings

	/// <summary>
	/// Represents tournament referee class.
	/// </summary>
	/// <seealso cref="TennisTournament.BusinessEntities.Participant" />
	public class Referee: Participant
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets the license got date.
		/// </summary>
		/// <value>
		/// The license got date.
		/// </value>
		public DateTime LicenseGot { get; set; }

		/// <summary>
		/// Gets or sets the license renewal date.
		/// </summary>
		/// <value>
		/// The license renewal date.
		/// </value>
		public DateTime LicenseRenewal { get; set; }

		#endregion Public Properties
	}
}
