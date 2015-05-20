namespace Facebook.Types
{
	/// <summary>
	/// Facebook Enums
	/// </summary>
	public class Enums
	{
		#region Extended_Permissions enum

		/// <summary>
		/// Extended Permissions
		/// </summary>
		public enum Extended_Permissions
		{
			/// <summary>
			/// Status Update
			/// </summary>
			status_update,
			/// <summary>
			/// Photo Upload
			/// </summary>
			photo_upload,
			/// <summary>
			/// Create a listing
			/// </summary>
			create_listing
		}

		/// <summary>
		/// Extended Permissions
		/// </summary>
		public enum NodeTypes
		{
			/// <summary>
			/// The URI of an image or picture, default is Resources.missingImage
			/// </summary>
			ImageURL,
			/// <summary>
			/// A double-precision floating-point number, default is 0.0
			/// </summary>
			Double,
			/// <summary>
			/// A date time, deafult is 1/1/1900
			/// </summary>
			DateTime,
			/// <summary>
			/// An Integer, default value is -1
			/// </summary>
			Int
		}

		#endregion
	}
}