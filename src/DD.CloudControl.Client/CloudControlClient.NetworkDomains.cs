using HTTPlease;
using HTTPlease.Formatters;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DD.CloudControl.Client
{
    using Models.Network;

	/// <summary>
    ///		The CloudControl API client. 
    /// </summary>
	public partial class CloudControlClient
	{
		/// <summary>
		/// 	Retrieve a list of network domains in the specified datacenter.
		/// </summary>
		/// <param name="datacenterId">
		/// 	An optional <see cref="Paging"/> configuration for the results.
		/// </param>
		/// <param name="paging">
		/// 	The Id of the target datacenter (e.g. AU10, NA9).
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the operation.
		/// </param>
		/// <returns>
		/// 	A <see cref="NetworkDomains"/> representing the page of results.
		/// </returns>
		public async Task<NetworkDomains> ListNetworkDomains(string datacenterId, Paging paging = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			Guid organizationId = await GetOrganizationId();

			HttpRequest request = Requests.Network.ListNetworkDomains
				.WithTemplateParameters(new
				{
					organizationId,
					datacenterId
				});

			if (paging != null)
			{
				request = request.WithTemplateParameters(new
				{
					pageNumber = paging.PageNumber,
					pageSize = paging.PageSize
				});
			}

			using (HttpResponseMessage response = await _httpClient.GetAsync(request, cancellationToken))
			{
				if (!response.IsSuccessStatusCode)
					throw await CloudControlException.FromApiV2Response(response);

				return await response.ReadContentAsAsync<NetworkDomains>();
			}
		}
	}
}