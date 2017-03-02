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
		/// 	Create a new NAT rule.
		/// </summary>
		/// <param name="networkDomainId">
		/// 	The Id of the network domain in which the NAT rule will be created.
		/// </param>
		/// <param name="internalIPAddress">
		/// 	The internal IPv4 address targeted by the NAT rule.
		/// </param>
		/// <param name="externalIPAddress">
		/// 	The external IPv4 address targeted by the NAT rule.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	The Id of the new NAT rule.
		/// </returns>
		public async Task<Guid> CreateNatRule(Guid networkDomainId, string internalIPAddress, string externalIPAddress, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (networkDomainId == Guid.Empty)
				throw new ArgumentException("Must supply a valid network domain Id.", nameof(networkDomainId));

			if (String.IsNullOrWhiteSpace(internalIPAddress))
				throw new ArgumentException("Must supply a internal IP address.", nameof(internalIPAddress));

			if (String.IsNullOrWhiteSpace(externalIPAddress))
				throw new ArgumentException("Must supply a internal IP address.", nameof(externalIPAddress));

			Guid organizationId = await GetOrganizationId();
			HttpRequest createNatRule = Requests.Network.CreateNatRule.WithTemplateParameter("organizationId", organizationId);

			HttpResponseMessage response = await
				_httpClient.PostAsJsonAsync(createNatRule,
					new CreateNatRule
					{
						NetworkDomainId = networkDomainId,
						InternalIPAddress = internalIPAddress,
						ExternalIPAddress = externalIPAddress
					},
					cancellationToken
				);
			using (response)
			{
				ApiResponseV2 apiResponse = await response.ReadContentAsApiResponseV2();
				if (apiResponse.ResponseCode != ApiResponseCodeV2.InProgress)
					throw CloudControlException.FromApiV2Response(apiResponse, response.StatusCode);

				string natRuleId = apiResponse.InfoMessages.GetByName("natRuleId");
				if (String.IsNullOrWhiteSpace(natRuleId))
					throw new CloudControlException("Received an unexpected response from the CloudControl API (missing 'natRuleId' message).");

				return new Guid(natRuleId);
			}
		}

		/// <summary>
		/// 	Retrieve a specific NAT rule by Id.
		/// </summary>
		/// <param name="natRuleId">
		/// 	The Id of the NAT rule to retrieve.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	A <see cref="NatRule"/> representing the NAT rule, or <c>null</c> if no NAT rule was found with the specified Id.
		/// </returns>
		public async Task<NatRule> GetNatRule(Guid natRuleId, CancellationToken cancellationToken = default(CancellationToken))
		{
			Guid organizationId = await GetOrganizationId();

			HttpRequest getNatRule = Requests.Network.GetNatRuleById
				.WithTemplateParameters(new
				{
					organizationId,
					natRuleId
				});

			using (HttpResponseMessage response = await _httpClient.GetAsync(getNatRule, cancellationToken))
			{
				if (!response.IsSuccessStatusCode)
				{
					ApiResponseV2 apiResponse = await response.ReadContentAsApiResponseV2();
					if (apiResponse.ResponseCode == ApiResponseCodeV2.ResourceNotFound)
						return null;

					throw CloudControlException.FromApiV2Response(apiResponse, response.StatusCode);
				}

				return await response.ReadContentAsAsync<NatRule>();
			}
		}

		/// <summary>
		/// 	Retrieve a list of NAT rules in the specified network domain.
		/// </summary>
		/// <param name="networkDomainId">
		/// 	The Id of the target network domain.
		/// </param>
		/// <param name="paging">
		/// 	An optional <see cref="Paging"/> configuration for the results.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	A <see cref="NatRules"/> representing the page of results.
		/// </returns>
		public async Task<NatRules> ListNatRules(Guid networkDomainId, Paging paging = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			Guid organizationId = await GetOrganizationId();

			HttpRequest listNatRules = Requests.Network.ListNatRules
				.WithTemplateParameters(new
				{
					organizationId,
					networkDomainId
				})
				.WithPaging(paging);

			using (HttpResponseMessage response = await _httpClient.GetAsync(listNatRules, cancellationToken))
			{
				if (!response.IsSuccessStatusCode)
					throw await CloudControlException.FromApiV2Response(response);

				return await response.ReadContentAsAsync<NatRules>();
			}
		}

		/// <summary>
		/// 	Delete an MCP 2.0 NAT rule.
		/// </summary>
		/// <param name="id">
		/// 	The Id of the NAT rule to delete.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	The CloudControl API response.
		/// </returns>
		/// <remarks>
		/// 	Deletion of NAT rules is asynchronous.
		/// </remarks>
		public async Task<ApiResponseV2> DeleteNatRule(Guid id, CancellationToken cancellationToken = default(CancellationToken))
		{
			Guid organizationId = await GetOrganizationId();

			HttpRequest deleteNatRule = Requests.Network.DeleteNatRule
				.WithTemplateParameters(new
				{
					organizationId
				});

			HttpResponseMessage response = await
				_httpClient.PostAsJsonAsync(deleteNatRule,
					new DeleteResource { Id = id },
					cancellationToken
				);
			using (response)
			{
				return await response.ReadContentAsApiResponseV2();
			}
		}
	}
}
