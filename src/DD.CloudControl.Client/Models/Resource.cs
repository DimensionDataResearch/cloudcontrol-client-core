using Newtonsoft.Json;
using System;

namespace DD.CloudControl.Client.Models
{
	/// <summary>
	/// 	The base class for resources in CloudControl.
	/// </summary>
	public abstract class Resource
	{
		/// <summary>
		/// 	Create a new <see cref="Resource"/>.
		/// </summary>
		protected Resource()
		{
		}

		/// <summary>
		/// 	The resource Id.
		/// </summary>
		[JsonProperty("id")]
		public Guid Id { get; set; }

		/// <summary>
		/// 	The UTC date / time that the resource was created.
		/// </summary>
		[JsonProperty("createTime")]
		public DateTime CreateTimeUTC { get; set; }

		/// <summary>
		/// 	The resource's current state.
		/// </summary>
		[JsonProperty("state")]
		public ResourceState State { get; set; }
	}
}