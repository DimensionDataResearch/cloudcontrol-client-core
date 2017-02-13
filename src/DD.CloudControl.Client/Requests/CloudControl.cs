using HTTPlease;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DD.CloudControl.Client.Requests
{
	/// <summary>
	///		Common request definitions for the CloudControl API. 
	/// </summary>
	public static class CloudControl
	{
		/// <summary>
		///		The base definition for CloudControl v1 API requests.
		/// </summary>
		public static readonly HttpRequest BaseRequestV1 =
			HttpRequest.Factory.Create("oec/0.9")
				.UseXmlSerializer()
				.ExpectXml();

		/// <summary>
		///		The base definition for CloudControl v2.2 API requests.
		/// </summary>
		public static readonly HttpRequest BaseRequestV22 =
			HttpRequest.Factory.Create("caas/2.2")
				.UseJson(JsonSettings)
				.UseXmlSerializer() // Errors always come back as XML (go figure)
				.ExpectJson();

		/// <summary>
		///		The base definition for CloudControl v2.3 API requests.
		/// </summary>
		public static readonly HttpRequest BaseRequestV23 =
			HttpRequest.Create("caas/2.3")
				.UseJson(JsonSettings)
				.UseXmlSerializer() // Errors always come back as XML (go figure)
				.ExpectJson();

		/// <summary>
		///		The base definition for CloudControl v2.3 API requests.
		/// </summary>
		public static readonly HttpRequest BaseRequestV24 =
			HttpRequest.Create("caas/2.4")
				.UseJson(JsonSettings)
				.UseXmlSerializer() // Errors always come back as XML (go figure)
				.ExpectJson();

		/// <summary>
		/// 	JSON serialisation settings for the CloudControl API.
		/// </summary>
		static JsonSerializerSettings JsonSettings => new JsonSerializerSettings
		{
			Converters =
			{
				new StringEnumConverter()
			},
			DateFormatHandling = DateFormatHandling.IsoDateFormat
		};
	}
}