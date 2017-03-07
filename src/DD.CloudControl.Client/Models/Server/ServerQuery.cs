using System;

namespace DD.CloudControl.Client.Models.Server
{
	/// <summary>
	/// 	The query configuration for listing servers.
	/// </summary>
	public class ServerQuery
	{
		/// <summary>
		/// 	Only return servers in the specified network domain.
		/// </summary>
		public Guid? NetworkDomainId { get; set; }

		/// <summary>
		/// 	Create a <see cref="ServerQuery"/> that returns all servers.
		/// </summary>
		/// <returns>
		/// 	The configured <see cref="ServerQuery"/>.
		/// </returns>
		public static ServerQuery All() => new ServerQuery();

		/// <summary>
		/// 	Create a <see cref="ServerQuery"/> that returns all servers in the specified network domain.
		/// </summary>
		/// <param name="networkDomainId">
		/// 	The network domain Id.
		/// </param>
		/// <returns>
		/// 	The configured <see cref="ServerQuery"/>.
		/// </returns>
		public static ServerQuery ByNetworkDomain(Guid networkDomainId) => new ServerQuery { NetworkDomainId = networkDomainId };
	}
}