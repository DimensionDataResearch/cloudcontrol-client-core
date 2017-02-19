using System.Collections.Generic;
using Newtonsoft.Json;

namespace DD.CloudControl.Client.Models.Network
{
	/// <summary>
	/// 	Represents an MCP 2.0 network domain.
	/// </summary>
	public class NetworkDomain
		: Resource
	{
		/// <summary>
		/// 	The network domain name.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 	The network domain description.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// 	The Id of the datacenter (e.g. AU10, NA9) in which the network domain is located.
		/// </summary>
		[JsonProperty("datacenterId")]
		public string DatacenterId { get; set; }

		/// <summary>
		/// 	The network domain type.
		/// </summary>
		/// <remarks>
		/// 	Determines which features are available in the network domain.
		/// </remarks>
		[JsonProperty("type")]
		public NetworkDomainType Type { get; set; }
		
		/// <summary>
		/// 	The network domain's source NAT (S/NAT) IPv4 address.
		/// </summary>
		/// <remarks>
		/// 	This is the IPv4 address from which outgoing traffic from the network domain appears to originate.
		/// </remarks>
		[JsonProperty("snatIpv4Address")]
		public string SnatIPv4Address { get; set; }

		/// <summary>
		/// 	The subnet reserved for the network domain's outside-transit VLAN.
		/// </summary>
		/// <remarks>
		/// 	Each Network Domain uses a portion of the 100.64.0.0/10 range for transit routing.
		/// 	You cannot use this space for VLANs or any other purpose.
		/// </remarks>
		[JsonProperty("outsideTransitVlanIpv4Subnet", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public Subnet OutsideTransitVlanIpv4Subnet { get; } = new Subnet();
	}

	/// <summary>
	/// 	A page of <see cref="NetworkDomain"/>s.
	/// </summary>
	[JsonObject]
	public class NetworkDomains
		: PagedResult<NetworkDomain>
	{
		/// <summary>
		/// 	The network domains.
		/// </summary>
		[JsonProperty("networkDomain", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public override List<NetworkDomain> Items { get; } = new List<NetworkDomain>();
	}
}