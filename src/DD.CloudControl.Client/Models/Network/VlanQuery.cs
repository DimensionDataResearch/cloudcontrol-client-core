using System;

namespace DD.CloudControl.Client.Models.Network
{
	/// <summary>
	/// 	The query configuration for listing VLANs.
	/// </summary>
	public class VlanQuery
	{
		/// <summary>
		/// 	Only return VLANs with specified name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 	Only return VLANs in the specified network domain.
		/// </summary>
		public Guid? NetworkDomainId { get; set; }

		/// <summary>
		/// 	Create a <see cref="VlanQuery"/> that returns all VLANs.
		/// </summary>
		/// <returns>
		/// 	The configured <see cref="VlanQuery"/>.
		/// </returns>
		public static VlanQuery All() => new VlanQuery();

		/// <summary>
		/// 	Create a <see cref="VlanQuery"/> that returns all VLANs with the specified name.
		/// </summary>
		/// <param name="name">
		/// 	The name to match.
		/// </param>
		/// <returns>
		/// 	The configured <see cref="VlanQuery"/>.
		/// </returns>
		public static VlanQuery ByName(string name) => new VlanQuery { Name = name };

		/// <summary>
		/// 	Create a <see cref="VlanQuery"/> that returns all VLANs with the specified name in the specified network domain.
		/// </summary>
		/// <param name="name">
		/// 	The name to match.
		/// </param>
		/// <param name="networkDomainId">
		/// 	The Id of the target network domain.
		/// </param>
		/// <returns>
		/// 	The configured <see cref="VlanQuery"/>.
		/// </returns>
		public static VlanQuery ByNameAndNetworkDomain(string name, Guid networkDomainId) => new VlanQuery { Name = name, NetworkDomainId = networkDomainId };

		/// <summary>
		/// 	Create a <see cref="VlanQuery"/> that returns all VLANs in the specified datacenter.
		/// </summary>
		/// <param name="networkDomainId">
		/// 	The Id of the target network domain.
		/// </param>
		/// <returns>
		/// 	The configured <see cref="VlanQuery"/>.
		/// </returns>
		public static VlanQuery ByNetworkDomain(Guid networkDomainId) => new VlanQuery { NetworkDomainId = networkDomainId };
	}
}