using HTTPlease.Testability;
using System.Threading.Tasks;
using System.Net;
using Xunit;

namespace DD.CloudControl.Client.Tests
{
	using Models.Directory;

    /// <summary>
    /// 	Tests for the client's account APIs.
    /// </summary>
    public class AccountTests
		: ClientTestBase
	{
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
			CloudControlClient client = CreateCloudControlClient(request =>
			{
				MessageAssert.AcceptsMediaType(request, "text/xml");
				MessageAssert.HasRequestUri(request,
					CreateApiUri("oec/0.9/myaccount")
				);

				return request.CreateResponse(HttpStatusCode.OK, MyAccountXml, mediaType: "text/xml");
			});
			
			using (client)
			{
				UserAccount account = await client.GetAccount();
				Assert.NotNull(account);
				Assert.Equal("test_user", account.UserName);
				Assert.Equal("Test User", account.FullName);
				Assert.Equal("Test", account.FirstName);
				Assert.Equal("User", account.LastName);
				Assert.Equal("test.user@mycompany.com", account.EmailAddress);
				Assert.Equal("Department 1", account.Department);
				Assert.Equal(TestOrganizationId, account.OrganizationId);
			}
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
    <ns8:orgId>22edd5e3-a235-4d3c-b5b2-d2843aa77d41</ns8:orgId>
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