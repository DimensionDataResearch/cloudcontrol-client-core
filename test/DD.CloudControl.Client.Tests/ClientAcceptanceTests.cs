using System;
using System.Threading.Tasks;
using Xunit;

namespace DD.CloudControl.Client.Tests
{
    using Models.Directory;
	using Models.Network;
	using Utilities;

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
		/// 	Get the current user's account details.
		/// </summary>
		[AcceptanceFact]
		public async Task Client_GetAccount()
		{
			CloudControlClient client = CloudControlClient.Create(
				baseUri: new Uri("https://api-au.dimensiondata.com/"),
				userName: Credentials.User,
				password: Credentials.Password
			);

			using (client)
			{
				UserAccount account = await client.GetAccount();
				Assert.NotNull(account);
				Assert.Equal(Credentials.User, account.UserName);
			}
		}

		/// <summary>
		/// 	Get the current user's account details.
		/// </summary>
		[AcceptanceFact]
		public async Task Client_CreateNetworkDomain()
		{
			Console.WriteLine(
				$"User = '{Credentials.User}', Password = '{Credentials.Password}'"
			);

			CloudControlClient client = CloudControlClient.Create(
				baseUri: new Uri("https://api-au.dimensiondata.com/"),
				userName: Credentials.User,
				password: Credentials.Password
			);

			using (client)
			{
				Guid networkDomainId = await client.CreateNetworkDomain("AU9", "CCC_ACCTEST", "CloudControl Client Acceptance Test", NetworkDomainType.Essentials);
				Console.WriteLine(
					$"networkDomainId = {networkDomainId}"
				);
			}
		}

		/// <summary>
		/// 	List network domains in the "AU9" (Sydney) datacenter.
		/// </summary>
		[AcceptanceFact]
		public async Task Client_ListNetworkDomains_AU9()
		{
			CloudControlClient client = CloudControlClient.Create(
				baseUri: new Uri("https://api-au.dimensiondata.com/"),
				userName: Credentials.User,
				password: Credentials.Password
			);

			using (client)
			{
				Paging page = new Paging
				{
					PageSize = 20
				};

				NetworkDomainQuery query = NetworkDomainQuery.ByDatacenter("AU9");
				NetworkDomains networkDomains = await client.ListNetworkDomains(query, page);
				int expectedTotalCount = networkDomains.TotalCount;
				int totalCount = 0;
				while (!networkDomains.IsEmpty)
				{
					totalCount += networkDomains.PageCount;
					
					foreach (NetworkDomain networkDomain in networkDomains)
						Console.WriteLine("NetworkDomain: " + networkDomain.Name);

					page++;
					networkDomains = await client.ListNetworkDomains(query, page);
				}

				Assert.Equal(expectedTotalCount, totalCount);
			}
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
