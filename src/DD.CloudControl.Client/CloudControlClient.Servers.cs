using HTTPlease;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DD.CloudControl.Client
{
	using Models;
	using Models.Server;

	/// <summary>
	///		The CloudControl API client. 
	/// </summary>
	public partial class CloudControlClient
	{
		/// <summary>
		/// 	Create a new server.
		/// </summary>
		/// <param name="deploymentConfiguration">
		/// 	The configuration that the new server will be deployed with.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	The Id of the new server.
		/// </returns>
		public async Task<Guid> CreateServer(ServerDeploymentConfiguration deploymentConfiguration, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (deploymentConfiguration == null)
				throw new ArgumentNullException(nameof(deploymentConfiguration));

			Guid organizationId = await GetOrganizationId();
			HttpRequest createServer = Requests.Server.CreateServer.WithTemplateParameter("organizationId", organizationId);

			using (HttpResponseMessage response = await _httpClient.PostAsJsonAsync(createServer, deploymentConfiguration, cancellationToken))
			{
				ApiResponseV2 apiResponse = await response.ReadContentAsApiResponseV2();
				if (apiResponse.ResponseCode != ApiResponseCodeV2.InProgress)
					throw CloudControlException.FromApiV2Response(apiResponse, response.StatusCode);

				string serverId = apiResponse.InfoMessages.GetByName("serverId");
				if (String.IsNullOrWhiteSpace(serverId))
					throw new CloudControlException("Received an unexpected response from the CloudControl API (missing 'serverId' message).");

				return new Guid(serverId);
			}
		}

		/// <summary>
		/// 	Retrieve a specific server by Id.
		/// </summary>
		/// <param name="serverId">
		/// 	The Id of the server to retrieve.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	A <see cref="Server"/> representing the server, or <c>null</c> if no server was found with the specified Id.
		/// </returns>
		public async Task<Server> GetServer(Guid serverId, CancellationToken cancellationToken = default(CancellationToken))
		{
			Guid organizationId = await GetOrganizationId();

			HttpRequest getServer = Requests.Server.GetServerById
				.WithTemplateParameters(new
				{
					organizationId,
					serverId
				});

			using (HttpResponseMessage response = await _httpClient.GetAsync(getServer, cancellationToken))
			{
				if (!response.IsSuccessStatusCode)
				{
					ApiResponseV2 apiResponse = await response.ReadContentAsApiResponseV2();
					if (apiResponse.ResponseCode == ApiResponseCodeV2.ResourceNotFound)
						return null;

					throw CloudControlException.FromApiV2Response(apiResponse, response.StatusCode);
				}

				return await response.ReadContentAsAsync<Server>();
			}
		}

		/// <summary>
		/// 	Retrieve a list of servers.
		/// </summary>
		/// <param name="query">
		/// 	A <see cref="ServerQuery"/> that determines which servers will be retrieved.
		/// </param>
		/// <param name="paging">
		/// 	An optional <see cref="Paging"/> configuration for the results.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	A <see cref="Servers"/> representing the page of results.
		/// </returns>
		public async Task<Servers> ListServers(ServerQuery query, Paging paging = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (query == null)
				throw new ArgumentNullException(nameof(query));
			
			Guid organizationId = await GetOrganizationId();

			HttpRequest listServers = Requests.Server.ListServers
				.WithTemplateParameters(new
				{
					organizationId,
					networkDomainId = query.NetworkDomainId
				})
				.WithPaging(paging);

			using (HttpResponseMessage response = await _httpClient.GetAsync(listServers, cancellationToken))
			{
				if (!response.IsSuccessStatusCode)
					throw await CloudControlException.FromApiV2Response(response);

				return await response.ReadContentAsAsync<Servers>();
			}
		}

		/// <summary>
		/// 	Delete an MCP 2.0 server.
		/// </summary>
		/// <param name="id">
		/// 	The Id of the server to delete.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	The CloudControl API response.
		/// </returns>
		/// <remarks>
		/// 	Deletion of servers is asynchronous.
		/// </remarks>
		public async Task<ApiResponseV2> DeleteServer(Guid id, CancellationToken cancellationToken = default(CancellationToken))
		{
			Guid organizationId = await GetOrganizationId();

			HttpRequest deleteServer = Requests.Server.DeleteServer
				.WithTemplateParameters(new
				{
					organizationId
				});

			HttpResponseMessage response = await
				_httpClient.PostAsJsonAsync(deleteServer,
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
