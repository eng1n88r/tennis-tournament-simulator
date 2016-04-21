namespace TennisTournament.BusinessEntities
{
	#region Usings

	using System;
	
	#endregion Usings

	/// <summary>
	/// Represents tournament player class.
	/// </summary>
	/// <seealso cref="TennisTournament.BusinessEntities.Participant" />
	public class Player: Participant
	{
		#region Public Methods

		/// <summary>
		/// Calculates the age.
		/// </summary>
		/// <returns>Returns the age of the player.</returns>
		public int CalculateAge()
		{
			var today = DateTime.Today;
			int age = today.Year - DateOfBirth.Year;

			if (DateOfBirth > today.AddYears(-age))
			{
				age--;
			}

			return age;
		}

		#endregion Public Methods
	}
}
	