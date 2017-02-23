using System;
using Newtonsoft.Json;

namespace DD.CloudControl.Client.Models.Network
{
	/// <summary>
	/// 	The model used to request expanding of an MCP 2.0 VLAN's private IPv4 network address space.
	/// </summary>
	public class ExpandVlan
	{
		/// <summary>
		/// 	The Id of the VLAN to edit.
		/// </summary>
		[JsonProperty("name")]
		public Guid Id { get; set; }

		/// <summary>
		/// 	The new prefix size for the VLAN's private IPv4 network.
		/// </summary>
		[JsonProperty("name")]
		public int PrivateIPv4PrefixSize { get; set; }
	}
}