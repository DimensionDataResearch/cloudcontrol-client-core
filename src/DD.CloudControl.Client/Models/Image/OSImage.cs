using Newtonsoft.Json;
using System.Collections.Generic;

namespace DD.CloudControl.Client.Models.Image
{
    /// <summary>
    /// 	Represents a vendor-supplied image in CloudControl.
    /// </summary>
    public class OSImage
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
	public class OSImages
		: PagedResult<OSImage>
	{
		/// <summary>
		/// 	The OS images.
		/// </summary>
		[JsonProperty("osImage", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public override List<OSImage> Items { get; } = new List<OSImage>();
	}
}