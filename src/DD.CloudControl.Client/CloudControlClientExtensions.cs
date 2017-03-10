using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DD.CloudControl.Client
{
	using Models.Network;
	using Models.Server;

	/// <summary>
	/// 	Extension methods for <see cref="CloudControlClient"/>.
	/// </summary>
	public static class CloudControlClientExtensions
	{
		/// <summary>
		/// 	List network domains in the specified datacenter.
		/// </summary>
		/// <param name="client">
		/// 	The CloudControl API client.
		/// </param>
		/// <param name="datacenterId">
		/// 	The Id of the datacenter containing the network domain to retrieve.
		/// </param>
		/// <param name="paging">
		/// 	An optional <see cref="Paging"/> configuration for the results.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	The network domains (as <see cref="NetworkDomains"/>).
		/// </returns>
		public static Task<NetworkDomains> ListNetworkDomains(this CloudControlClient client, string datacenterId, Paging paging, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (client == null)
				throw new ArgumentNullException(nameof(client));
			
			NetworkDomainQuery query = NetworkDomainQuery.ByDatacenter(datacenterId);

			return client.ListNetworkDomains(query, paging, cancellationToken);
		}

		/// <summary>
		/// 	Retrieve the first network domain in the specified datacenter with the specified name.
		/// </summary>
		/// <param name="client">
		/// 	The CloudControl API client.
		/// </param>
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
		public static async Task<NetworkDomain> GetNetworkDomainByName(this CloudControlClient client, string name, string datacenterId, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (client == null)
				throw new ArgumentNullException(nameof(client));

			NetworkDomainQuery query = NetworkDomainQuery.ByNameAndDatacenter(name, datacenterId);
			NetworkDomains matchingNetworkDomains = await client.ListNetworkDomains(query, cancellationToken: cancellationToken);

			return matchingNetworkDomains.Items.FirstOrDefault();
		}

		/// <summary>
		/// 	Retrieve a list of VLANs in the specified network domain.
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
		/// 	A <see cref="Vlans"/> representing the page of results.
		/// </returns>
		public static Task<Vlans> ListVlans(this CloudControlClient client, Guid networkDomainId, Paging paging = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (client == null)
				throw new ArgumentNullException(nameof(client));
			
			VlanQuery query = VlanQuery.ByNetworkDomain(networkDomainId);

			return client.ListVlans(query, paging, cancellationToken);
		}

		/// <summary>
		/// 	Retrieve a specific VLAN by name and network domain.
		/// </summary>
		/// <param name="client">
		/// 	The CloudControl API client.
		/// </param>
		/// <param name="name">
		/// 	The name of the VLAN to retrieve.
		/// </param>
		/// <param name="networkDomainId">
		/// 	The Id of the network domain containing the VLAN to retrieve.
		/// </param>
		/// <param name="cancellationToken">
		/// 	An optional cancellation token that can be used to cancel the request.
		/// </param>
		/// <returns>
		/// 	A <see cref="NetworkDomain"/> representing the VLAN, or <c>null</c> if no network domain was found with the specified Id.
		/// </returns>
		public static async Task<Vlan> GetVlanByName(this CloudControlClient client, string name, Guid networkDomainId, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (client == null)
				throw new ArgumentNullException(nameof(client));
			
			VlanQuery query = VlanQuery.ByNameAndNetworkDomain(name, networkDomainId);

			Vlans matchingVlans = await client.ListVlans(query,
				cancellationToken: cancellationToken
			);
			
			return matchingVlans.Items.FirstOrDefault();
		}

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