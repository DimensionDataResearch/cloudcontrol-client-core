using System;
using System.Collections.Generic;
using System.Linq;

namespace DD.CloudControl.Client
{
	using Models.Common;
	using Models.Image;
	using Models.Server;

	/// <summary>
	/// 	Extension methods for CloudControl models.
	/// </summary>
	public static class ModelExtensions
	{
		/// <summary>
		/// 	Apply an image to the server deployment configuration.
		/// </summary>
		/// <param name="deploymentConfiguration">
		/// 	The server deployment configuration.
		/// </param>
		/// <param name="image">
		/// 	The image to apply.
		/// </param>
		public static void ApplyImage(this ServerDeploymentConfiguration deploymentConfiguration, Image image)
		{
			if (deploymentConfiguration == null)
				throw new ArgumentNullException(nameof(deploymentConfiguration));
			
			if (image == null)
				throw new ArgumentNullException(nameof(image));
			
			deploymentConfiguration.ImageId = image.Id;
			deploymentConfiguration.MemoryGB = image.MemoryGB;
			deploymentConfiguration.CPU.UpdateFrom(image.CPU);
			
			// Create or update disk configuration.
			Dictionary<int, VirtualMachineDisk> serverDisks = deploymentConfiguration.Disks.ToDictionary(disk => disk.ScsiUnitId);
			foreach (VirtualMachineDisk imageDisk in image.Disks)
			{
				VirtualMachineDisk serverDisk;
				if (!serverDisks.TryGetValue(imageDisk.ScsiUnitId, out serverDisk))
				{
					serverDisk = imageDisk.Clone(withId: false);
					deploymentConfiguration.Disks.Add(serverDisk);
				}

				serverDisk.SizeGB = imageDisk.SizeGB;
				serverDisk.Speed = imageDisk.Speed;
			}
		}

		/// <summary>
		/// 	Create a copy of the <see cref="VirtualMachineDisk"/>.
		/// </summary>
		/// <param name="disk">
		/// 	The disk to copy.
		/// </param>
		/// <param name="withId">
		/// 	Copy the disk's Id?
		/// </param>
		/// <returns>
		/// 	The new <see cref="VirtualMachineDisk"/>.
		/// </returns>
		public static VirtualMachineDisk Clone(this VirtualMachineDisk disk, bool withId = true)
		{
			if (disk == null)
				throw new ArgumentNullException(nameof(disk));

			return new VirtualMachineDisk
			{
				Id = withId ? disk.Id : Guid.Empty,
				ScsiUnitId = disk.ScsiUnitId,
				SizeGB = disk.SizeGB,
				Speed = disk.Speed
			};
		}

		/// <summary>
		/// 	Update the <see cref="VirtualMachineCPU"/> with values from another <see cref="VirtualMachineCPU"/>.
		/// </summary>
		/// <param name="cpu">
		/// 	The <see cref="VirtualMachineCPU"/> to update.
		/// </param>
		/// <param name="otherCPU">
		/// 	The other <see cref="VirtualMachineCPU"/>.
		/// </param>
		public static void UpdateFrom(this VirtualMachineCPU cpu, VirtualMachineCPU otherCPU)
		{
			if (cpu == null)
				throw new ArgumentNullException(nameof(cpu));

			if (otherCPU == null)
				throw new ArgumentNullException(nameof(otherCPU));
			
			cpu.Count = otherCPU.Count;
			cpu.Speed = otherCPU.Speed;
			cpu.CoresPerSocket = otherCPU.CoresPerSocket;
		}
	}
}