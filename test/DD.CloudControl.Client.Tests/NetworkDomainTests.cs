using System.Net;
using System.Threading.Tasks;
using HTTPlease.Testability;
using Xunit;

namespace DD.CloudControl.Client.Tests
{
	using Models.Network;

	/// <summary>
	/// 	Tests for the client's network domain APIs.
	/// </summary>
	public class NetworkDomainTests
		: ClientTestBase
	{
		/// <summary>
		/// 	List network domains (successful).
		/// </summary>
		[Fact]
		public async Task ListNetworkDomains_Success()
		{
			// TODO: Make CloudControlClient disposable.
			CloudControlClient client = CreateCloudControlClientWithUserAccount(request =>
			{
				MessageAssert.AcceptsMediaType(request,
					"application/json"
				);
				MessageAssert.HasRequestUri(request,
					CreateApiUri($"caas/2.4/{TestOrganizationId}/network/networkDomain/?datacenterId=AU9")
				);

				return request.CreateResponse(HttpStatusCode.OK,
					responseBody: TestResponses.ListNetworkDomains_Success,
					mediaType: "application/json"
				);
			});

			using (client)
			{
				NetworkDomains networkDomains = await client.ListNetworkDomains(datacenterId: "AU9");
				Assert.NotNull(networkDomains);
				Assert.Equal(2, networkDomains.TotalCount);
				Assert.Equal(2, networkDomains.Items.Count);
			}
		}

		/// <summary>
		/// 	Response bodies used in tests.
		/// </summary>
		static class TestResponses
		{
			/// <summary>
			/// 	Response for ListNetworkDomains (successful).
			/// </summary>
			public const string ListNetworkDomains_Success = @"
{
	""networkDomain"": [
	{
		""name"": ""Domain 1"",
		""description"": ""This is test domain 1"",
		""type"": ""ESSENTIALS"",
		""snatIpv4Address"": ""168.128.17.63"",
		""createTime"": ""2016-01-12T22:33:05.000Z"",
		""state"": ""NORMAL"",
		""id"": ""75ab2a57-b75e-4ec6-945a-e8c60164fdf6"",
		""datacenterId"": ""AU9""
	},
	{
		""name"": ""Domain 2"",
		""description"": """",
		""type"": ""ESSENTIALS"",
		""snatIpv4Address"": ""168.128.7.18"",
		""createTime"": ""2016-01-18T08:56:16.000Z"",
		""state"": ""NORMAL"",
		""id"": ""b91e0ba4-322c-32ca-bbc7-50b9a72d5f98"",
		""datacenterId"": ""AU9""
	}
	],
	""pageNumber"": 1,
	""pageCount"": 2,
	""totalCount"": 2,
	""pageSize"": 250
}
			";
		}
	}
}