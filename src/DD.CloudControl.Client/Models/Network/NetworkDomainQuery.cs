namespace DD.CloudControl.Client.Models.Network
{
	/// <summary>
	/// 	The query configuration for listing network domains.
	/// </summary>
	public class NetworkDomainQuery
	{
		/// <summary>
		/// 	Only return network domains with specified name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 	Only return network domains in the specified data center.
		/// </summary>
		public string DatacenterId { get; set; }

		/// <summary>
		/// 	Create a <see cref="NetworkDomainQuery"/> that returns all network domains.
		/// </summary>
		/// <returns>
		/// 	The configured <see cref="NetworkDomainQuery"/>.
		/// </returns>
		public static NetworkDomainQuery All() => new NetworkDomainQuery();

		/// <summary>
		/// 	Create a <see cref="NetworkDomainQuery"/> that returns all network domains with the specified name.
		/// </summary>
		/// <param name="name">
		/// 	The name to match.
		/// </param>
		/// <returns>
		/// 	The configured <see cref="NetworkDomainQuery"/>.
		/// </returns>
		public static NetworkDomainQuery ByName(string name) => new NetworkDomainQuery { Name = name };

		/// <summary>
		/// 	Create a <see cref="NetworkDomainQuery"/> that returns all network domains with the specified name in the specified datacenter.
		/// </summary>
		/// <param name="name">
		/// 	The name to match.
		/// </param>
		/// <param name="datacenterId">
		/// 	The Id of the target datacenter.
		/// </param>
		/// <returns>
		/// 	The configured <see cref="NetworkDomainQuery"/>.
		/// </returns>
		public static NetworkDomainQuery ByNameAndDatacenter(string name, string datacenterId) => new NetworkDomainQuery { Name = name, DatacenterId = datacenterId };

		/// <summary>
		/// 	Create a <see cref="NetworkDomainQuery"/> that returns all network domains in the specified datacenter.
		/// </summary>
		/// <param name="datacenterId">
		/// 	The Id of the target datacenter.
		/// </param>
		/// <returns>
		/// 	The configured <see cref="NetworkDomainQuery"/>.
		/// </returns>
		public static NetworkDomainQuery ByDatacenter(string datacenterId) => new NetworkDomainQuery { DatacenterId = datacenterId };
	}
}