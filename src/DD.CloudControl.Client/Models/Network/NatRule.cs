using System.Collections.Generic;
using Newtonsoft.Json;

namespace DD.CloudControl.Client.Models.Network
{
    /// <summary>
    /// 	Information about a CloudControl IPv4 NAT rule.
    /// </summary>
    public class NatRule
		: Resource
	{
		/// <summary>
		/// 	The Id of the datacenter (e.g. "AU9") where the nat rule is located.
		/// </summary>
		[JsonProperty("datacenterId")]
		public string DatacenterId { get; set; }

		/// <summary>
		/// 	The internal (private) IPv4 address targeted by the NAT rule.
		/// </summary>
		[JsonProperty("internalIp")]
		public string InternalIPAddress { get; set; }
		
		/// <summary>
		/// 	The external (public) IPv4 address targeted by the NAT rule.
		/// </summary>
		[JsonProperty("externalIp")]
		public string ExternalIPAddress { get; set; }

		/// <summary>
		/// 	The addressability of the external IP address.
		/// </summary>
		[JsonProperty("externalIpAddressability")]
		public ExternalIPAddressability ExternalIPAddressability { get; set; }
	}

	/// <summary>
	/// 	Represents a page of NAT rules.
	/// </summary>
	[JsonObject]
	public class NatRules
		: PagedResult<NatRule>
	{
		/// <summary>
		/// 	The NAT rules.
		/// </summary>
		[JsonProperty("natRule", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public override List<NatRule> Items { get; } = new List<NatRule>();
	}
}