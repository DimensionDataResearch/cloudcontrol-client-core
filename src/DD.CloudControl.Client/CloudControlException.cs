using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DD.CloudControl.Client
{
	using Models;

	/// <summary>
	/// 	Exception raised when the CloudControl client encounters an error.
	/// </summary>
	public class CloudControlException
		: Exception
	{
		/// <summary>
		/// 	Create a new <see cref="CloudControlException"/>.
		/// </summary>
		/// <param name="message">
		/// 	The exception message.
		/// </param>
		internal CloudControlException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// 	Create a new <see cref="CloudControlException"/>.
		/// </summary>
		/// <param name="message">
		/// 	The exception message.
		/// </param>
		/// <param name="innerException">
		/// 	The exception that caused the <see cref="CloudControlException"/> to be raised.
		/// </param>
		internal CloudControlException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// 	The CloudControl response code (if known).
		/// </summary>
		public string ResponseCode { get; private set; } = "Unknown";

		/// <summary>
		/// 	The HTTP status code (if known).
		/// </summary>
		public HttpStatusCode StatusCode { get; private set; } = 0;

		/// <summary>
		/// 	Create a <see cref="CloudControlException"/> from a v2 API response.
		/// </summary>
		/// <param name="response">
		/// 	The HTTP response message representing the .
		/// </param>
		/// <returns>
		/// 	The configured <see cref="CloudControlException"/>.
		/// </returns>
		public static async Task<CloudControlException> FromApiV2Response(HttpResponseMessage response)
		{
			if (response == null)
				throw new ArgumentNullException(nameof(response));

			ApiResponseV2 apiResponse = await response.ReadContentAsApiResponseV2();
			
			return FromApiV2Response(apiResponse, response.StatusCode);
		}

		/// <summary>
		/// 	Create a <see cref="CloudControlException"/> from a v2 API response.
		/// </summary>
		/// <param name="apiResponseV2">
		/// 	The API response.
		/// </param>
		/// <param name="statusCode">
		/// 	The HTTP status code.
		/// </param>
		/// <returns>
		/// 	The configured <see cref="CloudControlException"/>.
		/// </returns>
		public static CloudControlException FromApiV2Response(ApiResponseV2 apiResponseV2, HttpStatusCode statusCode)
		{
			if (apiResponseV2 == null)
				throw new ArgumentNullException(nameof(apiResponseV2));

			if (statusCode == 0)
				return FromApiV2Response(apiResponseV2);

			return new CloudControlException($"The CloudControl API returned an error response (HTTP {statusCode}): [{apiResponseV2.ResponseCode}] {apiResponseV2.Message}.")
			{
				ResponseCode = apiResponseV2.ResponseCode.ToString(),
				StatusCode = statusCode
			};
		}

		/// <summary>
		/// 	Create a <see cref="CloudControlException"/> from a v2 API response.
		/// </summary>
		/// <param name="apiResponseV2">
		/// 	The API response.
		/// </param>
		/// <returns>
		/// 	The configured <see cref="CloudControlException"/>.
		/// </returns>
		internal static CloudControlException FromApiV2Response(ApiResponseV2 apiResponseV2)
		{
			return new CloudControlException($"The CloudControl API returned an error response: [{apiResponseV2.ResponseCode}] {apiResponseV2.Message}.")
			{
				ResponseCode = apiResponseV2.ResponseCode.ToString(),
				StatusCode = 0
			};
		}
	}
}