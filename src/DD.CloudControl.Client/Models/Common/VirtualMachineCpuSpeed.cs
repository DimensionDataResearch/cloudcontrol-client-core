using System.Runtime.Serialization;

namespace DD.CloudControl.Client.Models.Common
{
    /// <summary>
    /// 	Available speeds for CPUs in CloudControl.
    /// </summary>
    public enum VirtualMachineCPUSpeed
	{
		/// <summary>
		///		An unknown CPU speed.
		/// </summary>
		/// <remarks>
		///		Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown = 0,

		/// <summary>
		///		Standard CPU speed.
		/// </summary>
		[EnumMember(Value = "STANDARD")]
		Standard = 1,

		/// <summary>
		///		High-performance CPU.
		/// </summary>
		[EnumMember(Value = "HIGHPERFORMANCE")]
		HighPerformance = 2
	}
}
