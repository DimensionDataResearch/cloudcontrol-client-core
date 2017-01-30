using System.Runtime.Serialization;

namespace DD.CloudControl.Client.Models.Network
{
	/// <summary>
	/// 	Well-known network domain types.
	/// </summary>
	public enum NetworkDomainType
	{
		/// <summary>
		///		An unknown network domain type.
		/// </summary>
		/// <remarks>
		///		Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown = 0,

		/// <summary>
		///		A basic network domain.
		/// </summary>
		/// <remarks>
		///		Supports all features except load-balancing and anti-affinity.
		/// </remarks>
		[EnumMember(Value = "ESSENTIALS")]
		Essentials = 1,

		/// <summary>
		///		An advanced network domain.
		/// </summary>
		/// <remarks>
		///		Supports all features, including load-balancing and anti-affinity.
		/// </remarks>
		[EnumMember(Value = "ADVANCED")]
		Advanced = 2
	}
}