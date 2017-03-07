using Newtonsoft.Json;
using System;

namespace DD.CloudControl.Client.Models.Server
{
    /// <summary>
    /// 	Represents the configuration for a disk in a virtual machine.
    /// </summary>
    public class VirtualMachineDisk
	{
		/// <summary>
		/// 	The disk Id, according to CloudControl.
		/// </summary>
		[JsonProperty("id")]
		public Guid Id { get; set; }

		/// <summary>
		/// 	The disk's SCSI unit Id.
		/// </summary>
		[JsonProperty("scsiId")]
		public int ScsiUnitId { get; set; }

		/// <summary>
		/// 	The disk size (in GB).
		/// </summary>
		[JsonProperty("sizeGb")]
		public int SizeGB { get; set; }

		/// <summary>
		/// 	The disk speed (performance level).
		/// </summary>
		[JsonProperty("speed")]
		public VirtualMachineDiskSpeed Speed { get; set; }
	}
}
