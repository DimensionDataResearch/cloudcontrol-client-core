using Newtonsoft.Json;

namespace DD.CloudControl.Client.Models
{
	/// <summary>
	/// 	The base class for pages of results from CloudControl.
	/// </summary>
	public abstract class PagedResult
	{
		/// <summary>
		/// 	The current page number.
		/// </summary>
		[JsonProperty("pageNumber")]
		public int PageNumber { get; set; }

		/// <summary>
		/// 	The number of items on the current page.
		/// </summary>
		[JsonProperty("pageCount")]
		public int PageCount { get; set; }

		/// <summary>
		/// 	The total number of items.
		/// </summary>
		[JsonProperty("totalCount")]
		public int TotalCount { get; set; }

		/// <summary>
		/// 	The maximum number of items per page.
		/// </summary>
		[JsonProperty("pageSize")]
		public int PageSize { get; set; }

		/// <summary>
		/// 	Is the page empty (i.e. no results?).
		/// </summary>
		public bool IsEmpty => PageCount == 0;
	}
}