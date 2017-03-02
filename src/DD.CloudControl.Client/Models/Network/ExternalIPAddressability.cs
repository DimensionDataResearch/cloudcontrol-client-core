using System.Runtime.Serialization;

namespace DD.CloudControl.Client.Models.Network
{
    /// <summary>
    /// 	Represents the accessibility of a NAT rule's external IPv4 address.
    /// </summary>
    public enum ExternalIPAddressability
	{
		/// <summary>
		/// 	IP address accessibility is unknown.
		/// </summary>
		/// <remarks>
		/// 	Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown = 0,

		/// <summary>
		/// 	IP address is private (non-internet-routable according to RFC1918).
		/// </summary>
		[EnumMember(Value = "PRIVATE_RFC1918")]
		PrivateRFC = 1,

		/// <summary>
		/// 	IP address is private (internet-routable according RFC1918).
		/// </summary>
		[EnumMember(Value = "PRIVATE_NON_RFC1918")]
		PrivateNonRFC = 2,

		/// <summary>
		/// 	IP address is publicly accessible.
		/// </summary>
		[EnumMember(Value = "PUBLIC_IP_BLOCK")]
		Public = 3
	}
}