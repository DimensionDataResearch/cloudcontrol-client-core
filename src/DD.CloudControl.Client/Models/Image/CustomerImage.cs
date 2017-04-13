using Newtonsoft.Json;
using System.Collections.Generic;

namespace DD.CloudControl.Client.Models.Image
{
    /// <summary>
    ///     Represents a Customer (customer-provided) server image in CloudControl.
    /// </summary>
    public class CustomerImage
        : Image
    {
        /// <summary>
        ///     The image type.
        /// </summary>
        [JsonIgnore]
        public override ImageType ImageType => ImageType.Customer;
    }

    /// <summary>
    ///     A page of <see cref="CustomerImage"/> results.
    /// </summary>
    public class CustomerImages
        : PagedResult<CustomerImage>
    {
        /// <summary>
        ///     The <see cref="CustomerImage"/> results.
        /// </summary>
        [JsonProperty("customerImages", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public override List<CustomerImage> Items { get; } = new List<CustomerImage>();
    }
}
