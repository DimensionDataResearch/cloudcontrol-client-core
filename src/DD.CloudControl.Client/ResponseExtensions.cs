using HTTPlease;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DD.CloudControl.Client
{
	using Models;

	/// <summary>
	/// 	Extensions for <see cref="HttpResponseMessage"/>.
	/// </summary>
	public static class ResponseExtensions
	{
		/// <summary>
		/// 	Read the response content as an <see cref="ApiResponseV2"/>.
		/// </summary>
		/// <param name="response">
		/// 	The HTTP response message.
		/// </param>
		/// <returns>
		/// 	The <see cref="ApiResponseV2"/>.
		/// </returns>
		public static async Task<ApiResponseV2> ReadContentAsApiResponseV2(this HttpResponseMessage response)
		{
			if (response == null)
				throw new ArgumentNullException(nameof(response));

			try
			{
				return await response.ReadContentAsAsync<ApiResponseV2>();
			}
			catch (Exception eReadApiResponse)
			{
				string requestMethod = response.RequestMessage?.Method?.Method ?? "UNKNOWN_METHOD";
				string requestUri = response.RequestMessage?.RequestUri?.AbsoluteUri ?? "UNKNOWN_URI";

				throw new CloudControlException(
					$"Failed to read {requestMethod} response from '{requestUri}' (HTTP status code {response.StatusCode}).",
					eReadApiResponse
				);
			}
		}
	}
}