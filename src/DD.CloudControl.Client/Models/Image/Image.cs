using Newtonsoft.Json;
using System.Collections.Generic;

namespace DD.CloudControl.Client.Models.Image
{
    using Common;

    /// <summary>
    ///     Represents a server (virtual machine) image in CloudControl.
    /// </summary>
    public abstract class Image
        : Resource
    {
        /// <summary>
        ///     The image type.
        /// </summary>
        /// <seealso cref="Models.Image.ImageType"/>
        [JsonIgnore]
        public abstract ImageType ImageType { get; }

        /// <summary>
        ///     The image name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
		/// 	The image description.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

        /// <summary>
        ///     The Id of the datacenter where the image is located.
        /// </summary>
        [JsonProperty("datacenterId")]
        public string DatacenterId { get; set; }

        /// <summary>
        ///     The image's operating system.
        /// </summary>
        [JsonProperty("operatingSystem", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public OperatingSystem OperatingSystem { get; } = new OperatingSystem();

        /// <summary>
        ///     The image's default CPU configuration.
        /// </summary>
        [JsonProperty("cpu", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public VirtualMachineCPU CPU { get; } = new VirtualMachineCPU();

        /// <summary>
        ///     The image's default memory size.
        /// </summary>
        [JsonProperty("memoryGb")]
        public int MemoryGB { get; set; }

        /// <summary>
        ///     The image's default disk configuration.
        /// </summary>
        [JsonProperty("disk", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public List<VirtualMachineDisk> Disks { get; } = new List<VirtualMachineDisk>();
    }
}
