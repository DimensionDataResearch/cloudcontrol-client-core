using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace DD.CloudControl.Client.Models
{
	/// <summary>
	/// 	The base class for pages of results from CloudControl.
	/// </summary>
	/// <typeparam name="TItem">
	/// 	The type of item in the results.
	/// </typeparam>
	[JsonObject]
	public abstract class PagedResult<TItem>
		: IEnumerable<TItem>
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

		/// <summary>
		/// 	The items in the current page.
		/// </summary>
		public abstract List<TItem> Items { get; }

		/// <summary>
		/// 	Get a typed enumerator for the items in the current page.
		/// </summary>
		/// <returns>
		/// 	The typed enumerator.
		/// </returns>
		public IEnumerator<TItem> GetEnumerator() => Items.GetEnumerator();

		/// <summary>
		/// 	Get an untyped enumerator for the items in the current page.
		/// </summary>
		/// <returns>
		/// 	The untyped enumerator.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
	}
}
