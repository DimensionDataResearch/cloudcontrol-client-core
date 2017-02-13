using System;
using System.Net;
using System.Threading.Tasks;
using HTTPlease.Testability;
using Xunit;

namespace DD.CloudControl.Client.Tests
{
	using Models.Network;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;

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
			CloudControlClient client = CreateCloudControlClientWithUserAccount(request =>
			{
				MessageAssert.AcceptsMediaType(request,
					"application/json"
				);
				MessageAssert.HasRequestUri(request,
					CreateApiUri($"caas/2.4/{TestOrganizationId}/network/networkDomain?datacenterId=AU9")
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
		/// 	List network domains (successful).
		/// </summary>
		[Fact]
		public async Task ListNetworkDomains_Paged_Success()
		{
			CloudControlClient client = CreateCloudControlClientWithUserAccount(request =>
			{
				MessageAssert.AcceptsMediaType(request,
					"application/json"
				);
				MessageAssert.HasRequestUri(request,
					CreateApiUri($"caas/2.4/{TestOrganizationId}/network/networkDomain?datacenterId=AU9&pageNumber=1&pageSize=250")
				);

				return request.CreateResponse(HttpStatusCode.OK,
					responseBody: TestResponses.ListNetworkDomains_Success,
					mediaType: "application/json"
				);
			});

			using (client)
			{
				NetworkDomains networkDomains = await client.ListNetworkDomains(
					datacenterId: "AU9",
					paging: new Paging
					{
						PageNumber = 1,
						PageSize = 250
					}
				);
				Assert.NotNull(networkDomains);
				Assert.Equal(2, networkDomains.TotalCount);
				Assert.Equal(2, networkDomains.Items.Count);
			}
		}

		/// <summary>
		/// 	Create a new network domain.
		/// </summary>
		[Fact]
		public async Task CreateNetworkDomain_Success()
		{
			CloudControlClient client = CreateCloudControlClientWithUserAccount(async request =>
			{
				MessageAssert.AcceptsMediaType(request,
					"application/json"
				);
				MessageAssert.HasRequestUri(request,
					CreateApiUri($"caas/2.4/{TestOrganizationId}/network/deployNetworkDomain")
				);

				JObject expectedRequestBody = (JObject)JToken.Parse(
					TestRequests.CreateNetworkDomain_Success
				);
				
				JObject actualRequestBody = (JObject)JToken.Parse(
					await request.Content.ReadAsStringAsync()
				);

				Assert.Equal(
					expectedRequestBody.ToString(Formatting.Indented).Trim(),
					actualRequestBody.ToString(Formatting.Indented).Trim()
				);

				return request.CreateResponse(HttpStatusCode.OK,
					responseBody: TestResponses.CreateNetworkDomain_Success,
					mediaType: "application/json"
				);
			});

			using (client)
			{
				Guid expectedNetworkDomainId = new Guid("f14a871f-9a25-470c-aef8-51e13202e1aa");
				Guid actualNetworkDomainId = await client.CreateNetworkDomain(
					datacenterId: "AU9",
					name: "A Network Domain",
					description: "This is a network domain",
					type: NetworkDomainType.Essentials
				);
				Assert.Equal(
					expectedNetworkDomainId,
					actualNetworkDomainId
				);
			}
		}

		/// <summary>
		/// 	Request bodies used in tests.
		/// </summary>
		static class TestRequests
		{
			/// <summary>
			/// 	Request for CreateNetworkDomain (successful).
			/// </summary>
			public const string CreateNetworkDomain_Success = @"
{
	""name"": ""A Network Domain"",
	""description"": ""This is a network domain"",
	""datacenterId"": ""AU9"",
	""type"": ""ESSENTIALS""	
}
			";
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

			/// <summary>
			/// 	Response for CreateNetworkDomain (successful).
			/// </summary>
			public const string CreateNetworkDomain_Success = @"
{
	""operation"": ""DEPLOY_NETWORK_DOMAIN"",
	""responseCode"": ""IN_PROGRESS"",
	""message"": ""Request to deploy Network Domain 'A Network Domain' has been accepted and is being processed."",
	""info"": [
		{
			""name"": ""networkDomainId"",
			""value"": ""f14a871f-9a25-470c-aef8-51e13202e1aa""
		}
	],
	""warning"": [],
	""error"": [],
	""requestId"": ""na9_20160321T074626030-0400_7e9fffe7-190b-46f2-9107-9d52fe57d0ad""
}
			";
		}
	}
}