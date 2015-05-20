namespace Facebook.Entity
{
	/// <summary>
	/// Represents the type of an object property.
	/// </summary>
	public enum ObjectPropertyType
	{
		/// <summary>
		/// Integer.
		/// </summary>
		Integer = 1,
		/// <summary>
		/// String with less than 255 characters.
		/// </summary>
		String = 2,
		/// <summary>
		/// Text blob which less than 64kb.
		/// </summary>
		TextBlob = 3
	}
}