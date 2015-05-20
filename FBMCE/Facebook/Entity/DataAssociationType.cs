namespace Facebook.Entity
{
	/// <summary>
	/// Type of data association.
	/// </summary>
	public enum DataAssociationType
	{
		/// <summary>
		/// One-way association, where reverse lookup is not needed.
		/// </summary>
		OneWay = 1,

		/// <summary>
		/// Two-way symmetric association, where a backward association
		/// (B to A) is always created when a forward association (A to B) is created.
		/// </summary>
		TwoWaySymmetric = 2,

		/// <summary>
		/// Two-way asymmetric association, where a backward association (B to A) has
		/// different meaning than a forward association (A to B).
		/// </summary>
		TwoWayAsymmetric = 3
	}
}