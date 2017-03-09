using Newtonsoft.Json;

namespace DD.CloudControl.Client.Models.Server
{
    /// <summary>
    /// 	The CPU configuration for a virtual machine.
    /// </summary>
    public class VirtualMachineCPU
	{
		/// <summary>
		/// 	The number of CPUs assigned to the virtual machine.
		/// </summary>
		[JsonProperty("count", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Count { get; set; }

		/// <summary>
		/// 	The speed (performance level) assigned to the virtual machine's CPU(s).
		/// </summary>
		[JsonProperty("speed", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public VirtualMachineCPUSpeed Speed { get; set ;}

		/// <summary>
		/// 	The number of cores per CPU.
		/// </summary>
		[JsonProperty("coresPerSocket", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CoresPerSocket { get; set; }
	}
}
