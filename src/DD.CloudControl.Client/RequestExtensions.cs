using System;
using HTTPlease;

namespace DD.CloudControl.Client
{
	/// <summary>
	/// 	Extension methods for CloudControl API <see cref="HttpRequest"/>s.
	/// </summary>
	static class RequestExtensions
	{
		/// <summary>
		/// 	Create a copy of the request, adding template parameters for paging if necessary.
		/// </summary>
		/// <param name="request">
		/// 	The request to copy.
		/// </param>
		/// <param name="paging">
		/// 	The paging configuration.
		/// </param>
		/// <returns>
		/// 	The new request.
		/// </returns>
		public static HttpRequest WithPaging(this HttpRequest request, Paging paging)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			if (paging == null)
				return request;

			return request.WithTemplateParameters(new
			{
				pageNumber = paging.PageNumber,
				pageSize = paging.PageSize
			});
		}
	}
}