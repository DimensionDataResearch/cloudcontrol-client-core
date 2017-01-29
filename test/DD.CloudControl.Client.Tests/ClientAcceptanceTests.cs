using System;
using System.Threading.Tasks;
using Xunit;

namespace DD.CloudControl.Client.Tests
{
	using Models.Directory;

	/// <summary>
	/// 	High-level acceptance tests for the CloudControl API client.
	/// </summary>
	/// <remarks>
	/// 	For the most part, tests use HTTPlease testability features to mock out the CloudControl API, but these tests will act as a placeholder for now.
	/// </remarks>
    public class ClientAcceptanceTests
		: IClassFixture<ClientCredentials>
    {
		/// <summary>
		/// 	Create a client acceptance-test suite.
		/// </summary>
		/// <param name="credentials">
		/// 	The client credentials for the CloudControl API.
		/// </param>
		public ClientAcceptanceTests(ClientCredentials credentials)
		{
			if (credentials == null)
				throw new ArgumentNullException(nameof(credentials));

			Credentials = credentials;
		}

		/// <summary>
		/// 	The client credentials for the CloudControl API.
		/// </summary>
		ClientCredentials Credentials { get; }

		/// <summary>
		/// 	Get a the current user's account details.
		/// </summary>
        // [Fact] TODO: Enable once we've moved this to DD.CloudControl.Client.AcceptanceTests.
        public async Task Client_GetAccount()
        {
			CloudControlClient client = CloudControlClient.Create(
				baseUri: new Uri("https://api-au.dimensiondata.com/"),
				userName: Credentials.User,
				password: Credentials.Password
			);

			UserAccount account = await client.GetAccount();
			Assert.NotNull(account);
			Assert.Equal(Credentials.User, account.UserName);
        }

		/// <summary>
		/// 	Create a new client for the CloudControl API.
		/// </summary>
		/// <returns>
		/// 	The configured <see cref="CloudControlClient"/>.
		/// </returns>
		CloudControlClient CreateClient() => CloudControlClient.Create(
			baseUri: new Uri("https://api-au.dimensiondata.com/"),
			userName: Credentials.User,
			password: Credentials.Password
		);
    }
}
