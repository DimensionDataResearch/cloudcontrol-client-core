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
		/// 	Create a new VLAN.
		/// </summary>
		/// <param name="name">
		/// 	The name of the new VLAN.
		/// </param>
		/// <param name="description">
		/// 	The description (if any) for the new VLAN.
		/// </param>
		/// <param name="networkDomainId">
		/// 	The Id of the network domain in which the VLAN will be created.
		/// </param>
		/// <param name="privateIPv4BaseAddress">
		/// 	The base address of the VLAN's private IPv4 network.
		/// </param>
		/// <param name="privateIPv4PrefixSize">
		/// 	The optional size, in bits, of the VLAN's private IPv4 network prefix.
		/// 	
		///		Default is 24 (i.e. a class C network).
		/// </param>
		/// <param name="gatewayAddressing">
		/// 	The gateway addressing style to use for the new VLAN.
		/// 	
		///		Default is <see cref="VlanGatewayAddressing.Low"/>.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	The Id of the new VLAN.
		/// </returns>
		public async Task<Guid> CreateVlan(string name, string description, Guid networkDomainId, string privateIPv4BaseAddress, int privateIPv4PrefixSize = 24, VlanGatewayAddressing gatewayAddressing = VlanGatewayAddressing.Low, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (String.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Must supply a valid name.", nameof(name));

			if (description == null)
				description = "";

			if (networkDomainId == Guid.Empty)
				throw new ArgumentException("Must supply a valid network domain Id.", nameof(networkDomainId));

			Guid organizationId = await GetOrganizationId();
			HttpRequest request = Requests.Network.CreateVlan.WithTemplateParameter("organizationId", organizationId);

			HttpResponseMessage response = await
				_httpClient.PostAsJsonAsync(request,
					new CreateVlan
					{
						Name = name,
						Description = description,
						NetworkDomainId = networkDomainId,
						PrivateIPv4BaseAddress = privateIPv4BaseAddress,
						PrivateIPv4PrefixSize = privateIPv4PrefixSize,
						GatewayAddressing = gatewayAddressing
					},
					cancellationToken
				);
			using (response)
			{
				ApiResponseV2 apiResponse = await response.ReadContentAsApiResponseV2();
				if (apiResponse.ResponseCode != ApiResponseCodeV2.InProgress)
					throw CloudControlException.FromApiV2Response(apiResponse, response.StatusCode);

				string vlanId = apiResponse.InfoMessages.GetByName("vlanId");
				if (String.IsNullOrWhiteSpace(vlanId))
					throw new CloudControlException("Received an unexpected response from the CloudControl API (missing 'vlanId' message).");

				return new Guid(vlanId);
			}
		}

		/// <summary>
		/// 	Retrieve a specific VLAN by Id.
		/// </summary>
		/// <param name="vlanId">
		/// 	The Id of the VLAN to retrieve.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	A <see cref="Vlan"/> representing the VLAN, or <c>null</c> if no VLAN was found with the specified Id.
		/// </returns>
		public async Task<Vlan> GetVlan(Guid vlanId, CancellationToken cancellationToken = default(CancellationToken))
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
		/// 	Retrieve a list of VLANs.
		/// </summary>
		/// <param name="query">
		/// 	A <see cref="VlanQuery"/> that determines which VLANs will be retrieved.
		/// </param>
		/// <param name="paging">
		/// 	An optional <see cref="Paging"/> configuration for the results.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	A <see cref="Vlans"/> representing the page of results.
		/// </returns>
		public async Task<Vlans> ListVlans(VlanQuery query, Paging paging = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (query == null)
				throw new ArgumentNullException(nameof(query));

			Guid organizationId = await GetOrganizationId();

			HttpRequest request = Requests.Network.ListVlans
				.WithTemplateParameters(new
				{
					organizationId,
					vlanName = query.Name,
					networkDomainId = query.NetworkDomainId
				})
				.WithPaging(paging);

			using (HttpResponseMessage response = await _httpClient.GetAsync(request, cancellationToken))
			{
				if (!response.IsSuccessStatusCode)
					throw await CloudControlException.FromApiV2Response(response);

				return await response.ReadContentAsAsync<Vlans>();
			}
		}

		/// <summary>
		/// 	Update an existing VLAN.
		/// </summary>
		/// <param name="vlan">
		/// 	The VLAN to update.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	The API response from CloudControl.
		/// </returns>
		public async Task<ApiResponseV2> EditVlan(Vlan vlan, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (vlan == null)
				throw new ArgumentNullException(nameof(vlan));

			Guid organizationId = await GetOrganizationId();
			HttpRequest request = Requests.Network.EditVlan.WithTemplateParameter("organizationId", organizationId);

			HttpResponseMessage response = await
				_httpClient.PostAsJsonAsync(request,
					new EditVlan
					{
						Id = vlan.Id,
						Name = vlan.Name,
						Description = vlan.Description
					},
					cancellationToken
				);
			using (response)
			{
				return await response.ReadContentAsApiResponseV2();
			}
		}

		/// <summary>
		/// 	Expand an existing VLAN.
		/// </summary>
		/// <param name="vlanId">
		/// 	The Id of the VLAN to expand.
		/// </param>
		/// <param name="privateIPv4PrefixSize">
		/// 	The new prefix size for the VLAN's private IPv4 network.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	The API response from CloudControl.
		/// </returns>
		public async Task<ApiResponseV2> ExpandVlan(Guid vlanId, int privateIPv4PrefixSize, CancellationToken cancellationToken = default(CancellationToken))
		{
			Guid organizationId = await GetOrganizationId();
			HttpRequest request = Requests.Network.ExpandVlan.WithTemplateParameter("organizationId", organizationId);

			HttpResponseMessage response = await
				_httpClient.PostAsJsonAsync(request,
					new ExpandVlan
					{
						Id = vlanId,
						PrivateIPv4PrefixSize = privateIPv4PrefixSize
					},
					cancellationToken
				);
			using (response)
			{
				return await response.ReadContentAsApiResponseV2();
			}
		}

		/// <summary>
		/// 	Delete an MCP 2.0 VLAN.
		/// </summary>
		/// <param name="id">
		/// 	The Id of the VLAN to delete.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	The CloudControl API response.
		/// </returns>
		/// <remarks>
		/// 	Deletion of VLANs is asynchronous.
		/// </remarks>
		public async Task<ApiResponseV2> DeleteVlan(Guid id, CancellationToken cancellationToken = default(CancellationToken))
		{
			Guid organizationId = await GetOrganizationId();

			HttpRequest request = Requests.Network.DeleteVlan
				.WithTemplateParameters(new
				{
					organizationId
				});

			HttpResponseMessage response = await
				_httpClient.PostAsJsonAsync(request,
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