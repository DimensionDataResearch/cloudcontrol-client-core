using System;
using System.Threading;
using System.Threading.Tasks;

namespace DD.CloudControl.Client
{
	using Models.Server;

	/// <summary>
	/// 	Extension methods for <see cref="CloudControlClient"/>.
	/// </summary>
	public static class CloudControlClientExtensions
	{
		/// <summary>
		/// 	Retrieve a list of servers in the specified network domain.
		/// </summary>
		/// <param name="client">
		/// 	The CloudControl API client.
		/// </param>
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
		/// 	A <see cref="Servers"/> representing the page of results.
		/// </returns>
		public static Task<Servers> ListServers(this CloudControlClient client, Guid networkDomainId, Paging paging = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (client == null)
				throw new ArgumentNullException(nameof(client));
			
			ServerQuery query = ServerQuery.ByNetworkDomain(networkDomainId);
			
			return client.ListServers(query, paging, cancellationToken);
		}
	}
}