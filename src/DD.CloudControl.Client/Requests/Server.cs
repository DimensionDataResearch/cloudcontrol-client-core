using HTTPlease;

namespace DD.CloudControl.Client.Requests
{
	/// <summary>
	/// 	Request definitions for the CloudControl server API.  
	/// </summary>
	public static class Server
	{
		/// <summary>
		///		Base request definition for server API requests. 
		/// </summary>
		static HttpRequest Base = CloudControl.BaseRequestV24.WithRelativeUri("{organizationId}/server");

		/// <summary>
		/// 	Request definition for retrieving a specific server by Id.
		/// </summary>
		public static HttpRequest GetServerById = Base.WithRelativeUri("server/{serverId}");

		/// <summary>
		/// 	Request definition for listing servers.
		/// </summary>
		public static HttpRequest ListServers = Base.WithRelativeUri("server?networkDomainId={networkDomainId?}&pageNumber={pageNumber?}&pageSize={pageSize?}");

		/// <summary>
		/// 	Request definition for creating a new server.
		/// </summary>
		public static HttpRequest CreateServer = Base.WithRelativeUri("deployServer");

		/// <summary>
		/// 	Request definition for updating an existing server.
		/// </summary>
		public static HttpRequest EditServer = Base.WithRelativeUri("editServer");

		/// <summary>
		/// 	Request definition for deleting a server.
		/// </summary>
		public static HttpRequest DeleteServer = Base.WithRelativeUri("deleteServer");
	}
}