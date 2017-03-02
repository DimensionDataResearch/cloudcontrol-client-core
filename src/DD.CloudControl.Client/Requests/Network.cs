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
		/// 	Request definition for updating an existing network domain.
		/// </summary>
		public static HttpRequest EditNetworkDomain = Base.WithRelativeUri("editNetworkDomain");

		/// <summary>
		/// 	Request definition for deleting a network domain.
		/// </summary>
		public static HttpRequest DeleteNetworkDomain = Base.WithRelativeUri("deleteNetworkDomain");

		/// <summary>
		/// 	Request definition for retrieving a specific network domain by Id.
		/// </summary>
		public static HttpRequest GetNetworkDomainById = Base.WithRelativeUri("networkDomain/{networkDomainId}");

		/// <summary>
		/// 	Request definition for retrieving a network domain by name.
		/// </summary>
		public static HttpRequest GetNetworkDomainByName = Base.WithRelativeUri("networkDomain?datacenterId={datacenterId}&name={name}");

		/// <summary>
		/// 	Request definition for listing network domains.
		/// </summary>
		public static HttpRequest ListNetworkDomains = Base.WithRelativeUri("networkDomain?datacenterId={datacenterId?}&pageNumber={pageNumber?}&pageSize={pageSize?}");

		/// <summary>
		/// 	Request definition for creating a new VLAN.
		/// </summary>
		public static HttpRequest CreateVlan = Base.WithRelativeUri("deployVlan");

		/// <summary>
		/// 	Request definition for updating an existing VLAN.
		/// </summary>
		public static HttpRequest EditVlan = Base.WithRelativeUri("editVlan");

		/// <summary>
		/// 	Request definition for expanding an existing VLAN's private IPv4 network address space.
		/// </summary>
		public static HttpRequest ExpandVlan = Base.WithRelativeUri("expandVlan");

		/// <summary>
		/// 	Request definition for deleting a VLAN.
		/// </summary>
		public static HttpRequest DeleteVlan = Base.WithRelativeUri("deleteVlan");

		/// <summary>
		/// 	Request definition for retrieving a specific VLAN by Id.
		/// </summary>
		public static HttpRequest GetVlanById = Base.WithRelativeUri("vlan/{vlanId}");

		/// <summary>
		/// 	Request definition for retrieving a VLAN by name.
		/// </summary>
		public static HttpRequest GetVlanByName = Base.WithRelativeUri("vlan?networkDomainId={networkDomainId}&name={name}");

		/// <summary>
		/// 	Request definition for listing VLANs in a network domain.
		/// </summary>
		public static HttpRequest ListVlansInNetworkDomain = Base.WithRelativeUri("vlan?networkDomainId={networkDomainId?}&pageNumber={pageNumber?}&pageSize={pageSize?}");

		/// <summary>
		/// 	Request definition for creating a new NAT rule.
		/// </summary>
		public static HttpRequest CreateNatRule = Base.WithRelativeUri("createNatRule");

		/// <summary>
		/// 	Request definition for retrieving a specific NAT rule by Id.
		/// </summary>
		public static HttpRequest GetNatRuleById = Base.WithRelativeUri("natRule/{natRuleId}");

		/// <summary>
		/// 	Request definition for listing NAT rules.
		/// </summary>
		public static HttpRequest ListNatRules = Base.WithRelativeUri("natRule?networkDomainId={networkDomainId?}&pageNumber={pageNumber?}&pageSize={pageSize?}");

		/// <summary>
		/// 	Request definition for deleting a NAT rule.
		/// </summary>
		public static HttpRequest DeleteNatRule = Base.WithRelativeUri("deleteNatRule");
	}
}