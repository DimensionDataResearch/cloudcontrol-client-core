using HTTPlease;

namespace DD.CloudControl.Client.Requests
{
	/// <summary>
	///     Request definitions for the CloudControl directory API.  
	/// </summary>
	public static class Directory
	{
		/// <summary>
        ///		Request definition for retrieving the current user's account information. 
        /// </summary>
		public static HttpRequest UserAccount = CloudControl.BaseRequestV1.WithRelativeUri("myaccount");
	}
}