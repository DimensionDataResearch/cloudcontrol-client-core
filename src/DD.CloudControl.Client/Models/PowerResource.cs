using Newtonsoft.Json;
using System;

namespace DD.CloudControl.Client.Models
{
	/// <summary>
	/// 	The model used to request start up and shutdown of an MCP 2.0 resource.
	/// </summary>
	public class PowerResource
	{
		/// <summary>
		/// 	The Id of the resource to perform a power option on
		/// </summary>
		[JsonProperty("id")]
		public Guid Id { get; set; }
	}
}