using System;
using HTTPlease;

namespace DD.CloudControl.Client.Requests
{
	/// <summary>
	/// 	Extension methods for CloudControl API <see cref="HttpRequest"/>s.
	/// </summary>
	public static class RequestExtensions
	{
		/// <summary>
		/// 	Create a copy of the request, adding paging parameters.
		/// </summary>
		/// <param name="request">
		/// 	The request to copy.
		/// </param>
		/// <param name="pageNumber">
		/// 	The requested page number.
		/// </param>
		/// <param name="pageSize">
		/// 	The requested page size.
		/// </param>
		/// <returns>
		/// 	The new request.
		/// </returns>
		public static HttpRequest WithPaging(this HttpRequest request, int pageNumber, int pageSize)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			return request
				.WithQueryParameter("page", pageNumber)
				.WithQueryParameter("pageSize", pageSize);
		}
	}
}