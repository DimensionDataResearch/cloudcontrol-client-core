using Newtonsoft.Json;

namespace DD.CloudControl.Client.Models.Network
{
	/// <summary>
	/// 	The model used to request creation of an MCP 2.0 network domain.
	/// </summary>
	public class CreateNetworkDomain
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
	}
}