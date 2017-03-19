using Newtonsoft.Json;
using System.Collections.Generic;

namespace DD.CloudControl.Client.Models.Image
{
    using Server;

    /// <summary>
    /// 	The base class for CloudControl images.
    /// </summary>
    public abstract class Image
		: Resource
	{
		/// <summary>
		/// 	The image name.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 	The image description.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// 	The Id of the datacenter where the image is located.
		/// </summary>
		[JsonProperty("datacenterId")]
		public string DatacenterId { get; set; }

		/// <summary>
		/// 	The image type.
		/// </summary>
		[JsonIgnore]
		public abstract ImageType ImageType { get; }

		/// <summary>
		/// 	Information about the image's operating system.
		/// </summary>
		[JsonProperty("operatingSystem", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public OperatingSystem OperatingSystem { get; } = new OperatingSystem();

		/// <summary>
		/// 	The default CPU configuration for servers created from the image.
		/// </summary>
		[JsonProperty("cpu", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public VirtualMachineCPU CPU { get; } = new VirtualMachineCPU();

		/// <summary>
		/// 	The default amount of memory (in gigabytes) allocated to servers created from the image.
		/// </summary>
		[JsonProperty("memoryGb")]
		public int MemoryGB { get; set; }

		/// <summary>
		/// 	The default disk configuration for virtual machines created from the image.
		/// </summary>
		[JsonProperty("disks", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public List<VirtualMachineDisk> Disks { get; } = new List<VirtualMachineDisk>();
	}
}
