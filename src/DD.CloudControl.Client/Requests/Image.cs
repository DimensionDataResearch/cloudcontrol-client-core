using HTTPlease;

namespace DD.CloudControl.Client.Requests
{
    /// <summary>
    ///     Request definitions for the CloudControl image API.  
    /// </summary>
    public static class Image
    {
        /// <summary>
		///		Base request definition for image API requests. 
		/// </summary>
		static HttpRequest Base = CloudControl.BaseRequestV24.WithRelativeUri("{organizationId}/image");

        /// <summary>
		/// 	Request definition for listing OS images.
		/// </summary>
		public static HttpRequest ListOSImages = Base.WithRelativeUri("customerImage?datacenterId={datacenterId?}&name={imageName?}&pageNumber={pageNumber?}&pageSize={pageSize?}");
    }
}
