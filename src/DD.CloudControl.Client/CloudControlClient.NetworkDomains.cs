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
		/// 	Retrieve a specific network domain by Id.
		/// </summary>
		/// <param name="networkDomainId">
		/// 	The Id of the network domain to retrieve.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	A <see cref="NetworkDomain"/> representing the network domain, or <c>null</c> if no network domain was found with the specified Id.
		/// </returns>
		public async Task<NetworkDomain> GetNetworkDomain(Guid networkDomainId, CancellationToken cancellationToken = default(CancellationToken))
		{
			Guid organizationId = await GetOrganizationId();

			HttpRequest request = Requests.Network.GetNetworkDomainById
				.WithTemplateParameters(new
				{
					organizationId,
					networkDomainId
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

				return await response.ReadContentAsAsync<NetworkDomain>();
			}
		}

		/// <summary>
		/// 	Retrieve a specific network domain by name and datacenter.
		/// </summary>
		/// <param name="name">
		/// 	The name of the network domain to retrieve.
		/// </param>
		/// <param name="datacenterId">
		/// 	The Id of the datacenter containing the network domain to retrieve.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	A <see cref="NetworkDomain"/> representing the network domain, or <c>null</c> if no network domain was found with the specified Id.
		/// </returns>
		public async Task<NetworkDomain> GetNetworkDomainByName(string name, string datacenterId, CancellationToken cancellationToken = default(CancellationToken))
		{
			Guid organizationId = await GetOrganizationId();

			HttpRequest request = Requests.Network.GetNetworkDomainByName
				.WithTemplateParameters(new
				{
					organizationId,
					name,
					datacenterId
				});

			using (HttpResponseMessage response = await _httpClient.GetAsync(request, cancellationToken))
			{
				if (!response.IsSuccessStatusCode)
					throw await CloudControlException.FromApiV2Response(response);

				NetworkDomains matchingNetworkDomains = await response.ReadContentAsAsync<NetworkDomains>();
				
				return !matchingNetworkDomains.IsEmpty ? matchingNetworkDomains.Items[0] : null;
			}
		}

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
		/// 	An optional cancellation token that can be used to cancel the request.
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
				})
				.WithPaging(paging);

			using (HttpResponseMessage response = await _httpClient.GetAsync(request, cancellationToken))
			{
				if (!response.IsSuccessStatusCode)
					throw await CloudControlException.FromApiV2Response(response);

				return await response.ReadContentAsAsync<NetworkDomains>();
			}
		}

		/// <summary>
		/// 	Create a new network domain.
		/// </summary>
		/// <param name="datacenterId">
		/// 	The Id of the target datacenter (e.g. AU10, NA9).
		/// </param>
		/// <param name="name">
		/// 	The name of the new network domain.
		/// </param>
		/// <param name="description">
		/// 	The description (if any) for the new network domain.
		/// </param>
		/// <param name="type">
		/// 	The network domain type.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	The Id of the new network domain.
		/// </returns>
		public async Task<Guid> CreateNetworkDomain(string datacenterId, string name, string description, NetworkDomainType type, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (String.IsNullOrWhiteSpace(datacenterId))
				throw new ArgumentException("Must supply a valid datacenter Id.", nameof(datacenterId));

			if (String.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Must supply a valid name.", nameof(name));

			if (description == null)
				description = "";

			Guid organizationId = await GetOrganizationId();
			HttpRequest request = Requests.Network.CreateNetworkDomain.WithTemplateParameter("organizationId", organizationId);

			HttpResponseMessage response = await
				_httpClient.PostAsJsonAsync(request,
					new CreateNetworkDomain
					{
						Name = name,
						Description = description,
						Type = type,
						DatacenterId = datacenterId
					},
					cancellationToken
				);
			using (response)
			{
				ApiResponseV2 apiResponse = await response.ReadContentAsApiResponseV2();
				if (apiResponse.ResponseCode != ApiResponseCodeV2.InProgress)
					throw CloudControlException.FromApiV2Response(apiResponse, response.StatusCode);

				string networkDomainId = apiResponse.InfoMessages.GetByName("networkDomainId");
				if (String.IsNullOrWhiteSpace(networkDomainId))
					throw new CloudControlException("Received an unexpected response from the CloudControl API (missing 'networkDomainId' message).");

				return new Guid(networkDomainId);
			}
		}

		/// <summary>
		/// 	Update an existing network domain.
		/// </summary>
		/// <param name="networkDomain">
		/// 	The network domain to update.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	The API response from CloudControl.
		/// </returns>
		public async Task<ApiResponseV2> EditNetworkDomain(NetworkDomain networkDomain, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (networkDomain == null)
				throw new ArgumentNullException(nameof(networkDomain));

			Guid organizationId = await GetOrganizationId();
			HttpRequest request = Requests.Network.EditNetworkDomain.WithTemplateParameter("organizationId", organizationId);

			HttpResponseMessage response = await
				_httpClient.PostAsJsonAsync(request,
					new EditNetworkDomain
					{
						Id = networkDomain.Id,
						Name = networkDomain.Name,
						Description = networkDomain.Description,
						Type = networkDomain.Type
					},
					cancellationToken
				);
			using (response)
			{
				return await response.ReadContentAsApiResponseV2();
			}
		}

		/// <summary>
		/// 	Delete an MCP 2.0 network domain.
		/// </summary>
		/// <param name="id">
		/// 	The Id of the network domain to delete.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <remarks>
		/// 	Deletion of network domains is synchronous.
		/// </remarks>
		public async Task DeleteNetworkDomain(Guid id, CancellationToken cancellationToken = default(CancellationToken))
		{
			Guid organizationId = await GetOrganizationId();

			HttpRequest request = Requests.Network.DeleteNetworkDomain
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
				ApiResponseV2 apiResponse = await response.ReadContentAsApiResponseV2();
				if (apiResponse.ResponseCode != ApiResponseCodeV2.Success)
					throw CloudControlException.FromApiV2Response(apiResponse, response.StatusCode);
			}
		}
	}
}