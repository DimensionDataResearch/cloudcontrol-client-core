using HTTPlease.Testability;
using System;
using System.Net.Http;

namespace DD.CloudControl.Client.Tests
{
	using Models.Directory;

	/// <summary>
	/// 	The base class for API client test suites.
	/// </summary>
	public abstract class ClientTestBase
	{
		/// <summary>
		/// 	The organisation Id used in tests.
		/// </summary>
		protected static readonly Guid OrganizationId = new Guid("22edd5e3-a235-4d3c-b5b2-d2843aa77d41");

		/// <summary>
		/// 	The base address for client APIs.
		/// </summary>
		protected static readonly Uri ApiBaseAddress = new Uri("http://fake.api/");

		/// <summary>
		/// 	Create a new API client test suite.
		/// </summary>
		protected ClientTestBase()
		{
		}

		/// <summary>
		/// 	Get the default user account information used in tests.
		/// </summary>
		protected static UserAccount GetDefaultUserAccount() => new UserAccount
		{
			UserName = "test_user",
			FirstName = "Test",
			LastName = "User",
			FullName = "Test User",
			EmailAddress = "test.user@mycompany.com",
			Department = "TestDepartment",
			OrganizationId = OrganizationId
		};

		/// <summary>
		/// 	Create a URI relative to the base addres for the CloudControl API.
		/// </summary>
		/// <param name="relativeUri">
		/// 	The relative URI.
		/// </param>
		/// <returns>
		/// 	The absolute URI.
		/// </returns>
		protected static Uri CreateApiUri(string relativeUri)
		{
			return CreateApiUri(
				new Uri(relativeUri, UriKind.Relative)
			);
		}

		/// <summary>
		/// 	Create a URI relative to the base addres for the CloudControl API.
		/// </summary>
		/// <param name="relativeUri">
		/// 	The relative URI.
		/// </param>
		/// <returns>
		/// 	The absolute URI.
		/// </returns>
		protected static Uri CreateApiUri(Uri relativeUri)
		{
			if (relativeUri == null)
				throw new ArgumentNullException(nameof(relativeUri));

			return new Uri(ApiBaseAddress, relativeUri);
		}
		
		/// <summary>
		/// 	Create a new CloudControl API client.
		/// </summary>
		/// <param name="httpClient">
		/// 	The HTTP client used to communicate with the CloudControl API.
		/// </param>
		/// <returns>
		/// 	The configured <see cref="CloudControlClient"/>.
		/// </returns>
		protected static CloudControlClient CreateCloudControlClient(Func<HttpRequestMessage, HttpResponseMessage> handler)
		{
			if (handler == null)
				throw new ArgumentNullException(nameof(handler));

			HttpClient httpClient = TestClients.RespondWith(handler);
			httpClient.BaseAddress = ApiBaseAddress;

			return new CloudControlClient(httpClient);
		}

		/// <summary>
		/// 	Create a new CloudControl API client pre-populated with the default user account details.
		/// </summary>
		/// <param name="httpClient">
		/// 	The HTTP client used to communicate with the CloudControl API.
		/// </param>
		/// <returns>
		/// 	The configured <see cref="CloudControlClient"/>.
		/// </returns>
		protected static CloudControlClient CreateCloudControlClientWithUserAccount(Func<HttpRequestMessage, HttpResponseMessage> handler)
		{
			if (handler == null)
				throw new ArgumentNullException(nameof(handler));

			HttpClient httpClient = TestClients.RespondWith(handler);
			httpClient.BaseAddress = ApiBaseAddress;

			return new CloudControlClient(httpClient,
				account: GetDefaultUserAccount()
			);
		}

		/// <summary>
		/// 	Create a new CloudControl API client.
		/// </summary>
		/// <param name="httpClient">
		/// 	The HTTP client used to communicate with the CloudControl API.
		/// </param>
		/// <returns>
		/// 	The configured <see cref="CloudControlClient"/>.
		/// </returns>
		protected static CloudControlClient CreateCloudControlClient(HttpClient httpClient)
		{
			if (httpClient == null)
				throw new ArgumentNullException(nameof(httpClient));

			httpClient.BaseAddress = ApiBaseAddress;

			return new CloudControlClient(httpClient);
		}
	}
}