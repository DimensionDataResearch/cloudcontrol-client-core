using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DD.CloudControl.Client.Models.Server
{
	using Common;

	/// <summary>
	/// 	The configuration for deploying a new server.
	/// </summary>
	public class ServerDeploymentConfiguration
	{
		/// <summary>
		/// 	A name for the new server.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 	An optional description for the new server.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// 	The Id of the image from which the server will be created.
		/// </summary>
		[JsonProperty("imageId")]
		public Guid ImageId { get; set; }

		/// <summary>
		/// 	The initial administrator password.
		/// </summary>
		[JsonProperty("administratorPassword")]
		public string AdministratorPassword { get; set; }

		/// <summary>
		/// 	The CPU configuration for the new server.
		/// </summary>
		[JsonProperty("cpu")]
		public VirtualMachineCPU CPU { get; set; }

		/// <summary>
		/// 	The amount of memory (in GB) allocated to the new server.
		/// </summary>
		[JsonProperty("memoryGb", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int MemoryGB { get; set; }

		/// <summary>
		/// 	The disk configuration for the new server.
		/// </summary>
		[JsonProperty("disk")]
		public List<VirtualMachineDisk> Disks { get; } = new List<VirtualMachineDisk>();

		/// <summary>
		/// 	The network configuration for the new server.
		/// </summary>
		[JsonProperty("networkInfo")]
		public VirtualMachineNetwork Network { get; } = new VirtualMachineNetwork();
		
		/// <summary>
		/// 	The primary DNS server IP for the new server.
		/// </summary>
		/// <remarks>
		/// 	If not specified, an appropriate default will be selected based on the target datacenter.
		/// </remarks>
		[JsonProperty("primaryDns", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PrimaryDNS { get; set; }

		/// <summary>
		/// 	The secondary DNS server IP for the new server.
		/// </summary>
		/// <remarks>
		/// 	If not specified, an appropriate default will be selected based on the target datacenter.
		/// </remarks>
		[JsonProperty("secondaryDns", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SecondaryDNS { get; set; }

		/// <summary>
		/// 	Automatically start the server once deployment is complete?
		/// </summary>
		[JsonProperty("start")]
		public bool Start { get; set; }		
	}
}