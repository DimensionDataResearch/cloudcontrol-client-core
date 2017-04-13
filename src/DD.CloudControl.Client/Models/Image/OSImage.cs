using Newtonsoft.Json;
using System.Collections.Generic;

namespace DD.CloudControl.Client.Models.Image
{
    /// <summary>
    ///     Represents an OS (vendor-provided) server image in CloudControl.
    /// </summary>
    public class OSImage
        : Image
    {
        /// <summary>
        ///     The image type.
        /// </summary>
        [JsonIgnore]
        public override ImageType ImageType => ImageType.OS;

        /// <summary>
        ///     The image key.
        /// </summary>
        [JsonProperty("osImageKey")]        
        public string OSImageKey { get; set; }
    }

    /// <summary>
    ///     A page of <see cref="OSImage"/> results.
    /// </summary>
    public class OSImages
        : PagedResult<OSImage>
    {
        /// <summary>
        ///     The <see cref="OSImage"/> results.
        /// </summary>
        [JsonProperty("osImages", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public override List<OSImage> Items { get; } = new List<OSImage>();
    }
}
