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
		/// 	Request definition for creating a new network domain.
		/// </summary>
		public static HttpRequest CreateNetworkDomain = Base.WithRelativeUri("deployNetworkDomain");

		/// <summary>
		/// 	Request definition for retrieving a specific network domain by Id.
		/// </summary>
		public static HttpRequest GetNetworkDomainById = Base.WithRelativeUri("networkDomain/{networkDomainId}");

		/// <summary>
		/// 	Request definition for listing network domains.
		/// </summary>
		public static HttpRequest ListNetworkDomains = Base.WithRelativeUri("networkDomain?datacenterId={datacenterId?}&pageNumber={pageNumber?}&pageSize={pageSize?}");

		/// <summary>
		/// 	Request definition for retrieving a specific VLAN by Id.
		/// </summary>
		public static HttpRequest GetVlanById = Base.WithRelativeUri("vlan/{vlanId}");
	}
}