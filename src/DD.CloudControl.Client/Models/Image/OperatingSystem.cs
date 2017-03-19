using Newtonsoft.Json;

namespace DD.CloudControl.Client.Models.Image
{
    /// <summary>
    /// 	Information held by the MCP about an operating system.
    /// </summary>
    public class OperatingSystem
	{
		/// <summary>
		/// 	The operating system Id.
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }
		
		/// <summary>
		/// 	The operating system type.
		/// </summary>
		[JsonProperty("family")]
		public string Family { get; set; }
		
		/// <summary>
		/// 	The operating system display name.
		/// </summary>
		[JsonProperty("displayName")]
		public string DisplayName { get; set; }
	}
}