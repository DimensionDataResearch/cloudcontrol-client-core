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
		[EnumMember(Value = "LOW")]
		Low = 1,

		/// <summary>
		///		VLAN uses high gateway addressing.
		/// </summary>
		[EnumMember(Value = "HIGH")]
		High = 2
	}
}