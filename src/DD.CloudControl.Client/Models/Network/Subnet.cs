using Newtonsoft.Json;

namespace DD.CloudControl.Client.Models.Network
{
	/// <summary>
	/// 	Represents an IP subnet.
	/// </summary>
	public class Subnet
	{
		/// <summary>
		/// 	The subnet IP address.
		/// </summary>
		[JsonProperty("address")]
		public string Address { get; set; }

		/// <summary>
		/// 	The subnet prefix size.
		/// </summary>
		[JsonProperty("prefixSize")]
		public int PrefixSize { get; set; }
	}
}