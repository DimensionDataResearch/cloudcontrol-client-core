using Newtonsoft.Json;
using System.Collections.Generic;

namespace DD.CloudControl.Client.Models.Image
{
    /// <summary>
    /// 	A user-supplied image.
    /// </summary>
    public class CustomerImage
		: Image
	{
		/// <summary>
		/// 	The image type.
		/// </summary>
		[JsonIgnore]
		public override ImageType ImageType => ImageType.OS;
	}

	/// <summary>
	/// 	Represents a page of OS images from CloudControl.
	/// </summary>
	public class CustomerImages
		: PagedResult<CustomerImage>
	{
		/// <summary>
		/// 	The customer images.
		/// </summary>
		[JsonProperty("customerImage", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public override List<CustomerImage> Items { get; } = new List<CustomerImage>();
	}
}
