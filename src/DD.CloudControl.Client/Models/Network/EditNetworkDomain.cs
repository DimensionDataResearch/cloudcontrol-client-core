using Newtonsoft.Json;
using System;

namespace DD.CloudControl.Client.Models.Network
{
	/// <summary>
	/// 	The model used to request an update of an MCP 2.0 network domain.
	/// </summary>
	public class EditNetworkDomain
	{
		/// <summary>
		/// 	The network domain Id.
		/// </summary>
		[JsonProperty("id")]
		public Guid Id { get; set; }

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
		/// 	The network domain type.
		/// </summary>
		/// <remarks>
		/// 	Determines which features are available in the network domain.
		/// </remarks>
		[JsonProperty("type")]
		public NetworkDomainType Type { get; set; }
	}
}