using System.Runtime.Serialization;

namespace DD.CloudControl.Client.Models.Common
{
    /// <summary>
    /// 	Available speeds for disks in CloudControl.
    /// </summary>
    public enum VirtualMachineDiskSpeed
	{
		/// <summary>
		///		An unknown disk speed.
		/// </summary>
		/// <remarks>
		///		Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown = 0,

		/// <summary>
		///		Slow disk.
		/// </summary>
		[EnumMember(Value = "LOW")]
		Low = 1,

        /// <summary>
        ///      Economy disk
        /// </summary>
        [EnumMember(Value = "ECONOMY")]
        Economy = 2,

		/// <summary>
		///		Standard disk speed.
		/// </summary>
		[EnumMember(Value = "STANDARD")]
		Standard = 3,

		/// <summary>
		///		High-performance disk.
		/// </summary>
		[EnumMember(Value = "HIGHPERFORMANCE")]
		HighPerformance = 4
	}
}
