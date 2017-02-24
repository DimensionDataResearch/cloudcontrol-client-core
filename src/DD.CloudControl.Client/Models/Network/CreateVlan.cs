using Newtonsoft.Json;
using System;

namespace DD.CloudControl.Client.Models.Network
{
	/// <summary>
	/// 	The model used to request creation of an MCP 2.0 VLAN.
	/// </summary>
	public class CreateVlan
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
		/// 	The Id of the network domain in which the VLAN will be created.
		/// </summary>
		[JsonProperty("networkDomainId")]
		public Guid NetworkDomainId { get; set; }

		/// <summary>
		///		The base address of the VLAN's private IPv4 network.
		/// </summary>
		[JsonProperty("privateIpv4BaseAddress")]
		public string PrivateIPv4BaseAddress { get; set; }

		/// <summary>
		///		The size (in bits) of the VLAN's private IPv4 network prefix.
		/// </summary>
		[JsonProperty("privateIpv4PrefixSize")]
		public int PrivateIPv4PrefixSize { get; set; }

		/// <summary>
		///		The VLAN's gateway addressing style.
		/// </summary>
		[JsonProperty("gatewayAddressing")]
		public VlanGatewayAddressing GatewayAddressing { get; set; }
	}
}