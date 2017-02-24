using HTTPlease.Testability;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DD.CloudControl.Client.Tests
{
    using Models.Network;

    /// <summary>
    /// 	Tests for the client's VLAN APIs.
    /// </summary>
    public class VlanTests
		: ClientTestBase
	{
		/// <summary>
		/// 	List VLANs (successful).
		/// </summary>
		[Fact]
		public async Task ListVlans_Success()
		{
			CloudControlClient client = CreateCloudControlClientWithUserAccount(request =>
			{
				MessageAssert.AcceptsMediaType(request,
					"application/json"
				);
				MessageAssert.HasRequestUri(request,
					CreateApiUri($"caas/2.4/{TestOrganizationId}/network/vlan?networkDomainId=909dd855-4b2c-49a9-8151-46969a1a9380")
				);

				return request.CreateResponse(HttpStatusCode.OK,
					responseBody: TestResponses.ListVlans_Success,
					mediaType: "application/json"
				);
			});

			using (client)
			{
				Vlans vlans = await client.ListVlans(networkDomainId: new Guid("909dd855-4b2c-49a9-8151-46969a1a9380"));
				Assert.NotNull(vlans);
				Assert.Equal(1, vlans.TotalCount);
				Assert.Equal(1, vlans.Items.Count);
			}
		}

		/// <summary>
		/// 	List a page of VLANs (successful).
		/// </summary>
		[Fact]
		public async Task ListVlans_Paged_Success()
		{
			CloudControlClient client = CreateCloudControlClientWithUserAccount(request =>
			{
				MessageAssert.AcceptsMediaType(request,
					"application/json"
				);
				MessageAssert.HasRequestUri(request,
					CreateApiUri($"caas/2.4/{TestOrganizationId}/network/vlan?networkDomainId=909dd855-4b2c-49a9-8151-46969a1a9380&pageNumber=1&pageSize=250")
				);

				return request.CreateResponse(HttpStatusCode.OK,
					responseBody: TestResponses.ListVlans_Success,
					mediaType: "application/json"
				);
			});

			using (client)
			{
				Vlans vlans = await client.ListVlans(
					networkDomainId: new Guid("909dd855-4b2c-49a9-8151-46969a1a9380"),
					paging: new Paging
					{
						PageNumber = 1,
						PageSize = 250
					}
				);
				Assert.NotNull(vlans);
				Assert.Equal(1, vlans.TotalCount);
				Assert.Equal(1, vlans.Items.Count);
			}
		}

		/// <summary>
		/// 	Response bodies used in tests.
		/// </summary>
		static class TestResponses
		{
			/// <summary>
			/// 	Response for ListVlans (successful).
			/// </summary>
			public const string ListVlans_Success = @"
{
    ""vlan"": [
        {
            ""networkDomain"": {
                ""id"": ""484174a2-ae74-4658-9e56-50fc90e086cf"",
                ""name"": ""Production Network Domain""
            },
            ""name"": ""Production VLAN"",
            ""description"": ""For hosting our Production Cloud Servers"",
            ""privateIpv4Range"": {
                ""address"": ""10.0.3.0"",
                ""prefixSize"": 24
            },
            ""ipv4GatewayAddress"": ""10.0.3.1"",
            ""ipv6Range"": {
                ""address"": ""2607:f480:1111:1153:0:0:0:0"",
                ""prefixSize"": 64
            },
            ""ipv6GatewayAddress"": ""2607:f480:1111:1153:0:0:0:1"",
            ""createTime"": ""2017-02-09T21:27:53.000Z"",
            ""state"": ""NORMAL"",
            ""id"": ""0e56433f-d808-4669-821d-812769517ff8"",
            ""datacenterId"": ""NA9""
        }
    ],
    ""pageNumber"": 1,
    ""pageCount"": 1,
    ""totalCount"": 1,
    ""pageSize"": 250
}
			";
		}
	}
}