using System;
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
		InvalidInputData = 3,

		/// <summary>
		/// 	The specified resource was not found.
		/// </summary>
		[EnumMember(Value = "RESOURCE_NOT_FOUND")]
		ResourceNotFound = 4
	}

	/// <summary>
	/// 	Extension methods for <see cref="ApiResponseV2"/> and friends.
	/// </summary>
	public static class ApiResponseExtensions
	{
		/// <summary>
		/// 	Get a message by name (if present).
		/// </summary>
		/// <param name="messages">
		/// 	The API response messages to examine.
		/// </param>
		/// <param name="name">
		/// 	The name of the target message.
		/// </param>
		/// <returns>
		/// 	The message value, or <c>null</c> if no message is present with the specified name.
		/// </returns>
		public static string GetByName(this IEnumerable<ApiMessageV2> messages, string name)
		{
			if (messages == null)
				throw new ArgumentNullException(nameof(messages));

			foreach (ApiMessageV2 message in messages)
			{
				if (message.Name == name)
					return message.Value;
			}

			return null;
		}

		/// <summary>
		/// 	Determine whether the specified API v2 response code indicates success.
		/// </summary>
		/// <param name="responseCode">
		/// 	The response code.
		/// </param>
		/// <returns>
		/// 	<c>true</c>, if the response code indicates success; otherwise, <c>false</c>.
		/// </returns>
		public static bool IndicatesSuccess(this ApiResponseCodeV2 responseCode)
		{
			switch (responseCode)
			{
				case ApiResponseCodeV2.Success:
				case ApiResponseCodeV2.InProgress:
				{
					return true;
				}
				default:
				{
					return false;
				}
			}
		}
	}
}