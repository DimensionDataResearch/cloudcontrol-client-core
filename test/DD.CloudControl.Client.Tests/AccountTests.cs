using HTTPlease.Testability;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using Xunit;

namespace DD.CloudControl.Client.Tests
{
	using Models.Directory;

    /// <summary>
    /// 	Tests for the client's Account APIs.
    /// </summary>
    public class AccountTests
	{
		/// <summary>
		/// 	The base address for client APIs.
		/// </summary>
		static readonly Uri ApiBaseAddress = new Uri("http://fake.api/");

		/// <summary>
		/// 	Create a new account test suite.
		/// </summary>
		public AccountTests()
		{
		}

		/// <summary>
		/// 	Retrieve account details (successful).
		/// </summary>
		[Fact]
		public async Task Get_Account_Success()
		{
			// TODO: Make CloudControlClient disposable.
			CloudControlClient client = CreateCloudControlClient(request =>
			{
				MessageAssert.AcceptsMediaType(request, "text/xml");
				MessageAssert.HasRequestUri(request,
					CreateApiUri("oec/0.9/myaccount")
				);

				return request.CreateResponse(HttpStatusCode.OK, MyAccountXml, mediaType: "text/xml");
			});
			
			UserAccount account = await client.GetAccount();
			Assert.NotNull(account);
			Assert.Equal("test_user", account.UserName);
			Assert.Equal("Test User", account.FullName);
			Assert.Equal("Test", account.FirstName);
			Assert.Equal("User", account.LastName);
			Assert.Equal("test.user@mycompany.com", account.EmailAddress);
			Assert.Equal("Department 1", account.Department);
			Assert.Equal(new Guid("f200382b-ff46-4878-9041-14a72009f9ad"), account.OrganizationId);
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
		static Uri CreateApiUri(string relativeUri)
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
		static Uri CreateApiUri(Uri relativeUri)
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
		static CloudControlClient CreateCloudControlClient(Func<HttpRequestMessage, HttpResponseMessage> handler)
		{
			if (handler == null)
				throw new ArgumentNullException(nameof(handler));

			HttpClient httpClient = TestClients.RespondWith(handler);
			httpClient.BaseAddress = ApiBaseAddress;

			return new CloudControlClient(httpClient);
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
		static CloudControlClient CreateCloudControlClient(HttpClient httpClient)
		{
			if (httpClient == null)
				throw new ArgumentNullException(nameof(httpClient));

			httpClient.BaseAddress = ApiBaseAddress;

			return new CloudControlClient(httpClient);
		}

		/// <summary>
		///		The XML returned by the "my account" API.
		/// </summary>
		const string MyAccountXml = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<ns8:Account xmlns=""http://oec.api.opsource.net/schemas/network"" xmlns:ns2=""http://oec.api.opsource.net/schemas/vip"" xmlns:ns4=""http://oec.api.opsource.net/schemas/organization"" xmlns:ns3=""http://oec.api.opsource.net/schemas/server"" xmlns:ns6=""http://oec.api.opsource.net/schemas/multigeo"" xmlns:ns5=""http://oec.api.opsource.net/schemas/datacenter"" xmlns:ns8=""http://oec.api.opsource.net/schemas/directory"" xmlns:ns7=""http://oec.api.opsource.net/schemas/general"" xmlns:ns13=""http://oec.api.opsource.net/schemas/support"" xmlns:ns9=""http://oec.api.opsource.net/schemas/serverbootstrap"" xmlns:ns12=""http://oec.api.opsource.net/schemas/storage"" xmlns:ns11=""http://oec.api.opsource.net/schemas/whitelabel"" xmlns:ns10=""http://oec.api.opsource.net/schemas/backup"" xmlns:ns16=""http://oec.api.opsource.net/schemas/manualimport"" xmlns:ns15=""http://oec.api.opsource.net/schemas/reset"" xmlns:ns14=""http://oec.api.opsource.net/schemas/admin"">
    <ns8:userName>test_user</ns8:userName>
    <ns8:fullName>Test User</ns8:fullName>
    <ns8:firstName>Test</ns8:firstName>
    <ns8:lastName>User</ns8:lastName>
    <ns8:emailAddress>test.user@mycompany.com</ns8:emailAddress>
    <ns8:department>Department 1</ns8:department>
    <ns8:customDefined1></ns8:customDefined1>
    <ns8:customDefined2></ns8:customDefined2>
    <ns8:orgId>f200382b-ff46-4878-9041-14a72009f9ad</ns8:orgId>
    <ns8:roles>
        <ns8:role>
            <ns8:name>server</ns8:name>
        </ns8:role>
        <ns8:role>
            <ns8:name>tag</ns8:name>
        </ns8:role>
        <ns8:role>
            <ns8:name>reports</ns8:name>
        </ns8:role>
        <ns8:role>
            <ns8:name>backup</ns8:name>
        </ns8:role>
        <ns8:role>
            <ns8:name>network</ns8:name>
        </ns8:role>
        <ns8:role>
            <ns8:name>create image</ns8:name>
        </ns8:role>
    </ns8:roles>
</ns8:Account>";
	}
}