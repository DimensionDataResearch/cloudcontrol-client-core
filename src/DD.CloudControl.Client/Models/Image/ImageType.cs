namespace DD.CloudControl.Client.Models.Image
{
	/// <summary>
	/// 	Well-known CloudControl image types.
	/// </summary>
	public enum ImageType
	{
		/// <summary>
		///		An image type.
		/// </summary>
		/// <remarks>
		///		Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown = 0,

		/// <summary>
		///		A vendor-supplied image.
		/// </summary>
		OS = 1,

		/// <summary>
		///		A user-supplied image.
		/// </summary>
		Customer = 2
	}
}
