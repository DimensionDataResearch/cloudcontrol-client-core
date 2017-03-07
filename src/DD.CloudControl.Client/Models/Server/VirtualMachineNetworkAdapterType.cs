using System.Runtime.Serialization;

namespace DD.CloudControl.Client.Models.Server
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

/*

// VirtualMachineNetwork represents the networking configuration for a virtual machine.
type VirtualMachineNetwork struct {
	NetworkDomainID           string                         `json:"networkDomainId,omitempty"`
	PrimaryAdapter            VirtualMachineNetworkAdapter   `json:"primaryNic"`
	AdditionalNetworkAdapters []VirtualMachineNetworkAdapter `json:"additionalNic"`
}

// VirtualMachineNetworkAdapter represents the configuration for a virtual machine's network adapter.
// If deploying a new VM, exactly one of VLANID / PrivateIPv4Address must be specified.
//
// AdapterType (if specified) must be either E1000 or VMXNET3.
type VirtualMachineNetworkAdapter struct {
	ID                 *string `json:"id,omitempty"`
	MACAddress         *string `json:"macAddress,omitempty"` // CloudControl v2.4 and higher
	VLANID             *string `json:"vlanId,omitempty"`
	VLANName           *string `json:"vlanName,omitempty"`
	PrivateIPv4Address *string `json:"privateIpv4,omitempty"`
	PrivateIPv6Address *string `json:"ipv6,omitempty"`
	AdapterType        *string `json:"networkAdapter,omitempty"`
	AdapterKey         *int    `json:"key,omitempty"` // CloudControl v2.4 and higher
	State              *string `json:"state,omitempty"`
}
	 */
}
