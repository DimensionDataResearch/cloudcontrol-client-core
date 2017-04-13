using Newtonsoft.Json;
using System;

namespace DD.CloudControl.Client.Models.Common
{
    /// <summary>
    /// 	The configuration for a virtual machine's network adapter.
    /// </summary>
    public class VirtualMachineNetworkAdapter
		: Resource
	{
		/// <summary>
		/// 	The network adapter's MAC address.
		/// </summary>
		[JsonProperty("macAddress", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MacAddress { get; set; }

		/// <summary>
		/// 	The Id of the VLAN that the network adapter is attached to.
		/// </summary>
		[JsonProperty("vlanId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Guid VlanId { get; set; }

		/// <summary>
		/// 	The name of the VLAN that the network adapter is attached to.
		/// </summary>
		[JsonProperty("vlanName", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string VlanName { get; set; }

		/// <summary>
		/// 	The network adapter's private IPv4 address.
		/// </summary>
		[JsonProperty("privateIpv4", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PrivateIPv4Address { get; set; }
		
		/// <summary>
		/// 	The network adapter's IPv6 address.
		/// </summary>
		[JsonProperty("ipv6", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IPv6Address { get; set; }

		/// <summary>
		/// 	The network adapter type.
		/// </summary>
		[JsonProperty("networkAdapter", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public VirtualMachineNetworkAdapterType AdapterType { get; set; }

		/// <summary>
		/// 	The network adapter key (uniquely identifies this adapter in the virtual machine).
		/// </summary>
		[JsonProperty("key", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AdapterKey { get; set; }
	}
}
