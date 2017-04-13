using System.Runtime.Serialization;

namespace DD.CloudControl.Client.Models.Common
{
    /// <summary>
    /// 	Well-known network adapter types for virtual machines.
    /// </summary>
    public enum VirtualMachineNetworkAdapterType
	{
		/// <summary>
		///		An unknown network adapter type.
		/// </summary>
		/// <remarks>
		///		Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown = 0,

		/// <summary>
		/// 	An Intel E1000 network adapter.
		/// </summary>
		[EnumMember(Value = "e1000")]
		E1000 = 1,

		/// <summary>
		/// 	A VMWare VMXNET (generation 3) network adapter.
		/// </summary>
		[EnumMember(Value = "vmxnet3")]
		VmxNet3 = 2
	}
}
