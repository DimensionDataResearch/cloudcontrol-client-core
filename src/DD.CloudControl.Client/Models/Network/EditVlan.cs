using System;
using Newtonsoft.Json;

namespace DD.CloudControl.Client.Models.Network
{
	/// <summary>
	/// 	The model used to request an update of an MCP 2.0 VLAN.
	/// </summary>
	public class EditVlan
	{
		/// <summary>
		/// 	The Id of the VLAN to edit.
		/// </summary>
		[JsonProperty("name")]
		public Guid Id { get; set; }

		/// <summary>
		/// 	A new name for the VLAN (or <c>null</c> to leave name as-is).
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 	A new description for the VLAN (or <c>null</c> to leave description as-is).
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }
	}
}