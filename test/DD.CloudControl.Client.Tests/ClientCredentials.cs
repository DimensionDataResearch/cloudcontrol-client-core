using System;

namespace DD.CloudControl.Client.Tests
{
	/// <summary>
	/// 	Client credentials for use in tests.
	/// </summary>
	public class ClientCredentials
	{
		/// <summary>
		/// 	Create new client credentials.
		/// </summary>
		public ClientCredentials()
		{
			if (Environment.GetEnvironmentVariable("CC_CLIENT_ACCTEST") != "1")
				return;

			User = Environment.GetEnvironmentVariable("MCP_USER");
			if (User == null)
				throw new InvalidOperationException("MCP_USER environment variable has not been specified.");

			Password = Environment.GetEnvironmentVariable("MCP_PASSWORD");
			if (Password == null)
				throw new InvalidOperationException("MCP_PASSWORD environment variable has not been specified.");
		}

		/// <summary>
		/// 	The user name for authenticating to the CloudControl API.
		/// </summary>
		public string User { get; } = "";

		/// <summary>
		/// 	The password for authenticating to the CloudControl API.
		/// </summary>
		public string Password { get; } = "";
	}
}