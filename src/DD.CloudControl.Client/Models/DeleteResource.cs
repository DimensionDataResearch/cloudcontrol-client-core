using Newtonsoft.Json;
using System;

namespace DD.CloudControl.Client.Models
{
	/// <summary>
	/// 	The model used to request deletion of an MCP 2.0 resource.
	/// </summary>
	public class DeleteResource
	{
		/// <summary>
		/// 	The Id of the resource to delete.
		/// </summary>
		[JsonProperty("id")]
		public Guid Id { get; set; }
	}
}