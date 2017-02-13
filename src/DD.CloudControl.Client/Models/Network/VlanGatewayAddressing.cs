using System.Runtime.Serialization;

namespace DD.CloudControl.Client.Models.Network
{
	/// <summary>
	/// 	Well-known VLAN gateway-addressing styles.
	/// </summary>
	public enum VlanGatewayAddressing
	{
		/// <summary>
		///		An unknown gateway-addressing style.
		/// </summary>
		/// <remarks>
		///		Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown = 0,

		/// <summary>
		///		VLAN uses low gateway addressing.
		/// </summary>
		/// <remarks>
		///		Addresses x.x.x.1-x.x.x.5 are reserved for gateways.
		/// </remarks>
		[EnumMember(Value = "LOW")]
		Low = 1,

		/// <summary>
		///		VLAN uses high gateway addressing.
		/// </summary>
		/// <remarks>
		///		Addresses x.x.x.252-x.x.x.254 are reserved for gateways.
		/// </remarks>
		[EnumMember(Value = "HIGH")]
		High = 2
	}
}