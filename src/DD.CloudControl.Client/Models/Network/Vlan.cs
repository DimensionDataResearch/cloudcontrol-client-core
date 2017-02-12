using Newtonsoft.Json;

namespace DD.CloudControl.Client.Models.Network
{
	/// <summary>
	/// 	Represents an MCP 2.0 network domain.
	/// </summary>
	public class Vlan
		: Resource
	{
		/// <summary>
		/// 	The VLAN name.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 	The VLAN description.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// 	A reference to the VLAN's network domain.
		/// </summary>
		[JsonProperty("networkDomain", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public EntityReference NetworkDomain { get; } = new EntityReference();

		/// <summary>
		/// 	The VLAN's private IPv4 network range.
		/// </summary>
		[JsonProperty("privateIpv4Range", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public Subnet PrivateIPv4Range { get; } = new Subnet();

		/// <summary>
		/// 	The address of the VLAN's IPv4 gateway.
		/// </summary>
		[JsonProperty("ipv4GatewayAddress")]
		public string IPv4GatewayAddress { get; set; }

		/// <summary>
		/// 	The VLAN's gateway-addressing style.
		/// </summary>
		/// <seealso cref="VlanGatewayAddressing"/>
		[JsonProperty("gatewayAddressing")]
		public VlanGatewayAddressing GatewayAddressing { get; set; }

		/// <summary>
		/// 	The VLAN's IPv6 network range.
		/// </summary>
		[JsonProperty("ipv6Range", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public Subnet IPv6Range { get; } = new Subnet();

		/// <summary>
		/// 	The address of the VLAN's IPv4 gateway.
		/// </summary>
		[JsonProperty("ipv6GatewayAddress")]
		public string IPv6GatewayAddress { get; set; }

		/// <summary>
		/// 	The Id of the datacenter (e.g. AU9) where the VLAN is deployed.
		/// </summary>
		[JsonProperty("datacenterId")]
		public string DatacenterId { get; set; }
	}
}