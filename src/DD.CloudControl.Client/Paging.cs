namespace DD.CloudControl.Client
{
	/// <summary>
	/// 	Paging options for the CloudControl API.
	/// </summary>
	public class Paging
	{
		/// <summary>
		/// 	The requested page number.
		/// </summary>
		public int PageNumber { get; set; } = 1;

		/// <summary>
		/// 	The maximum number of items per page.
		/// </summary>
		public int PageSize { get; set; }

		/// <summary>
		/// 	Configure the paging options for the next page.
		/// </summary>
		public void Next() => PageNumber++;

		/// <summary>
		/// 	Configure the paging options for the next page.
		/// </summary>
		public void Previous() => PageNumber--;

		/// <summary>
		/// 	Default paging options.
		/// </summary>
		public static Paging Default => new Paging { PageSize = 20 };

		/// <summary>
		/// 	Move to the next page.
		/// </summary>
		/// <param name="paging">
		/// 	The paging configuration.
		/// </param>
		/// <returns>
		/// 	The same paging configuration (modified in-place).
		/// </returns>
		public static Paging operator++(Paging paging)
		{
			paging.Next();

			return paging;
		}

		/// <summary>
		/// 	Move to the previous page.
		/// </summary>
		/// <param name="paging">
		/// 	The paging configuration.
		/// </param>
		/// <returns>
		/// 	The same paging configuration (modified in-place).
		/// </returns>
		public static Paging operator--(Paging paging)
		{
			paging.Previous();

			return paging;
		}
	}
}