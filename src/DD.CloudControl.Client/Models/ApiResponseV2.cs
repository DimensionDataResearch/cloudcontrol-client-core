using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DD.CloudControl.Client.Models
{
	/// <summary>
	/// 	Represents the generic response returned by the CloudControl v2.x API when no more specific response is required / available.
	/// </summary>
	public class ApiResponseV2
	{
		/// <summary>
		/// 	An identifier representing the operation being performed.
		/// </summary>
		[JsonProperty("operation")]
		public string Operation { get; set; }

		/// <summary>
		/// 	The response code associated with the operation.
		/// </summary>
		/// <seealso cref="ApiResponseCodeV2"/>
		[JsonProperty("responseCode")]
		public ApiResponseCodeV2 ResponseCode { get; set; }

		/// <summary>
		/// 	A message describing the response.
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }

		/// <summary>
		/// 	A unique identifier for the request that the response relates to.
		/// </summary>
		[JsonProperty("requestId")]
		public string RequestId { get; set; }

		/// <summary>
		/// 	Informational messages (if any) associated with the response.
		/// </summary>
		[JsonProperty("info", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public List<ApiMessageV2> InfoMessages { get; } = new List<ApiMessageV2>();

		/// <summary>
		/// 	Warning messages (if any) associated with the response.
		/// </summary>
		[JsonProperty("warning", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public List<ApiMessageV2> WarningMessages { get; } = new List<ApiMessageV2>();

		/// <summary>
		/// 	Error messages (if any) associated with the response.
		/// </summary>
		[JsonProperty("error", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
		public List<ApiMessageV2> ErrorMessages { get; } = new List<ApiMessageV2>();
	}

	/// <summary>
	/// 	Represents a message associated with a CloudControl API v2 response.
	/// </summary>
	public class ApiMessageV2
	{
		/// <summary>
		/// 	The message name.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 	The message value.
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }
	}

	/// <summary>
	/// 	Well-known response codes for the CloudControl v2 API.
	/// </summary>
	public enum ApiResponseCodeV2
	{
		/// <summary>
		/// 	An unknown response code.
		/// </summary>
		/// <remarks>
		///		Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown = 0,

		/// <summary>
		/// 	The operation completed successfully.
		/// </summary>
		[EnumMember(Value = "SUCCESS")]
		Success = 1,

		/// <summary>
		/// 	The operation started successfully, and is now in progress.
		/// </summary>
		[EnumMember(Value = "IN_PROGRESS")]
		InProgress = 2,

		/// <summary>
		/// 	Invalid input data was supplied in the request.
		/// </summary>
		[EnumMember(Value = "INVALID_INPUT_DATA")]
		InvalidInputData = 3
	}
}