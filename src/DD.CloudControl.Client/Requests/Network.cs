using HTTPlease;

namespace DD.CloudControl.Client.Requests
{
	/// <summary>
	/// 	Request definitions for the CloudControl network API.  
	/// </summary>
	public static class Network
	{
		/// <summary>
        ///		Base request definition for network API requests. 
        /// </summary>
		static HttpRequest Base = CloudControl.BaseRequestV24.WithRelativeUri("{organizationId}/network");

		/// <summary>
        ///		Base request definition for network domain API requests. 
        /// </summary>
		static HttpRequest NetworkDomain = Base.WithRelativeUri("networkDomain");

		/// <summary>
		/// 	Request definition for listing network domains.
		/// </summary>
		public static HttpRequest ListNetworkDomains = NetworkDomain.WithRelativeUri("?datacenterId={datacenterId?}&pageNumber={pageNumber?}&pageSize={pageSize?}");
	}
}