using System;
using Newtonsoft.Json;

namespace DD.CloudControl.Client.Models.Network
{
    /// <summary>
    /// 	Information about a CloudControl IPv4 NAT rule.
    /// </summary>
    public class CreateNatRule
	{
		/// <summary>
		/// 	The Id of the datacenter (e.g. "AU9") where the nat rule is located.
		/// </summary>
		[JsonProperty("networkDomainId")]
		public Guid NetworkDomainId { get; set; }

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
	}
}