using HTTPlease;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DD.CloudControl.Client
{
    using Models;
    using Models.Network;

	/// <summary>
    ///		The CloudControl API client. 
    /// </summary>
	public partial class CloudControlClient
	{
		/// <summary>
		/// 	Retrieve a specific VLAN by Id.
		/// </summary>
		/// <param name="vlanId">
		/// 	The Id of the VLAN to retrieve.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the operation.
		/// </param>
		/// <returns>
		/// 	A <see cref="Vlan"/> representing the VLAN, or <c>null</c> if no VLAN was found with the specified Id.
		/// </returns>
		public async Task<Vlan> GetVlan(string vlanId, CancellationToken cancellationToken = default(CancellationToken))
		{
			Guid organizationId = await GetOrganizationId();

			HttpRequest request = Requests.Network.GetVlanById
				.WithTemplateParameters(new
				{
					organizationId,
					vlanId
				});

			using (HttpResponseMessage response = await _httpClient.GetAsync(request, cancellationToken))
			{
				if (!response.IsSuccessStatusCode)
				{
					ApiResponseV2 apiResponse = await response.ReadContentAsApiResponseV2();
					if (apiResponse.ResponseCode == ApiResponseCodeV2.ResourceNotFound)
						return null;

					throw CloudControlException.FromApiV2Response(apiResponse, response.StatusCode);
				}

				return await response.ReadContentAsAsync<Vlan>();
			}
		}

		/// <summary>
		/// 	Retrieve a list of VLANs in the specified network domain.
		/// </summary>
		/// <param name="networkDomainId">
		/// 	The Id of the target network domain.
		/// </param>
		/// <param name="paging">
		/// 	An optional <see cref="Paging"/> configuration for the results.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the operation.
		/// </param>
		/// <returns>
		/// 	A <see cref="Vlans"/> representing the page of results.
		/// </returns>
		public async Task<Vlans> ListVlans(string networkDomainId, Paging paging = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			Guid organizationId = await GetOrganizationId();

			HttpRequest request = Requests.Network.ListVlansInNetworkDomain
				.WithTemplateParameters(new
				{
					organizationId,
					networkDomainId
				})
				.WithPaging(paging);

			using (HttpResponseMessage response = await _httpClient.GetAsync(request, cancellationToken))
			{
				if (!response.IsSuccessStatusCode)
					throw await CloudControlException.FromApiV2Response(response);

				return await response.ReadContentAsAsync<Vlans>();
			}
		}
	}
}