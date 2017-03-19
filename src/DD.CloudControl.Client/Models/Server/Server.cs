using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace DD.CloudControl.Client.Models.Server
{
	using Image;
	
    /// <summary>
    /// 	Represents an MCP 2.0 Server (virtual machine).
    /// </summary>
    public class Server
		: Resource
	{
		/// <summary>
		/// 	The server name.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 	The server description.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// 	Information about the server's operating system.
		/// </summary>
		[JsonProperty("operatingSystem", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public OperatingSystem OperatingSystem { get; } = new OperatingSystem();

		/// <summary>
		/// 	Information about the server's CPU(s).
		/// </summary>
		[JsonProperty("cpu", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public VirtualMachineCPU CPU { get; } = new VirtualMachineCPU();

		/// <summary>
		/// 	The amount of RAM (in gigabytes) assigned to the server.
		/// </summary>
		[JsonProperty("memoryGb")]
		public int MemoryGB { get; set; }

		/// <summary>
		/// 	The server's disk configuration.
		/// </summary>
		[JsonProperty("disk", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public List<VirtualMachineDisk> Disks { get; } = new List<VirtualMachineDisk>();

		/// <summary>
		/// 	The server's network configuration.
		/// </summary>
		[JsonProperty("networkInfo", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public VirtualMachineNetwork Network { get; } = new VirtualMachineNetwork();

		/// <summary>
		/// 	The Id of the image from which the server was created.
		/// </summary>
		public Guid SourceImageId { get; set; }

		/// <summary>
		/// 	Is the server's deployment complete?
		/// </summary>
		[JsonProperty("deployed")]
		public bool IsDeployed { get; set; }

		/// <summary>
		/// 	Is the server running?
		/// </summary>
		[JsonProperty("started")]
		public bool IsRunning { get; set; }
	}

	/// <summary>
	/// 	Represents a page of <see cref="Server"/> results.
	/// </summary>
	public class Servers
		: PagedResult<Server>
	{
		/// <summary>
		/// 	The servers.
		/// </summary>
		[JsonProperty("server", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public override List<Server> Items { get; } = new List<Server>();
	}
}
