using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace DD.CloudControl.Client.Models.Server
{
    /// <summary>
    /// 	Represents the network configuration for a virtual machine.
    /// </summary>
    public class VirtualMachineNetwork
	{
		/// <summary>
		/// 	The Id of the network domain where the virtual machine is deployed.
		/// </summary>
		[JsonProperty("networkDomainId")]
		public Guid NetworkDomainId { get; set; }

		/// <summary>
		/// 	Information about the virtual machine's primary network adapter.
		/// </summary>
		[JsonProperty("primaryNic")]
		public VirtualMachineNetworkAdapter PrimaryNetworkAdapter { get; }

		/// <summary>
		/// 	Information about the virtual machine's primary network adapter.
		/// </summary>
		[JsonProperty("additionalNic", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public List<VirtualMachineNetworkAdapter> AdditionalNetworkAdapters { get; } = new List<VirtualMachineNetworkAdapter>();

		/// <summary>
		/// 	Enumerate all configured network adapters.
		/// </summary>
		/// <returns>
		/// 	An <see cref="IEnumerable{T}"/> for the network adapters.
		/// </returns>
		public IEnumerable<VirtualMachineNetworkAdapter> AllNetworkAdapters()
		{
			if (PrimaryNetworkAdapter == null)
				yield break;

			yield return PrimaryNetworkAdapter;

			foreach (VirtualMachineNetworkAdapter additionalNetworkAdapter in AdditionalNetworkAdapters)
				yield return additionalNetworkAdapter;
		}
	}
}
