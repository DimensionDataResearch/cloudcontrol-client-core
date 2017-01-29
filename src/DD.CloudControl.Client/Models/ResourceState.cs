using System.Runtime.Serialization;

namespace DD.CloudControl.Client.Models
{
	/// <summary>
	/// 	Well-known states for resources in cloud control.
	/// </summary>
	public enum ResourceState
	{
		/// <summary>
		///		Resource state is unknown.
		/// </summary>
		/// <remarks>
		///		Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown = 0,

		/// <summary>
		///		Resource is in its normal state.
		/// </summary>
		[EnumMember(Value = "NORMAL")]
		Normal = 1,

		/// <summary>
		///		Resource is being created.
		/// </summary>
		[EnumMember(Value = "PENDING_ADD")]
		PendingAdd = 2,

		/// <summary>
		///		Resource is being modified.
		/// </summary>
		[EnumMember(Value = "PENDING_CHANGE")]
		PendingChange = 3,

		/// <summary>
		///		Resource is being deleted.
		/// </summary>
		[EnumMember(Value = "PENDING_DELETE")]
		PendingDelete = 4,

		/// <summary>
		///		Resource creation failed.
		/// </summary>
		[EnumMember(Value = "FAILED_ADD")]
		FailedAdd = 5,

		/// <summary>
		///		Resource modification failed.
		/// </summary>
		[EnumMember(Value = "FAILED_CHANGE")]
		FailedChange = 6,

		/// <summary>
		///		Resource deletion failed.
		/// </summary>
		[EnumMember(Value = "FAILED_DELETE")]
		FailedDelete = 7,

		/// <summary>
		///		Resource state is invalid; please contact support to resolve.
		/// </summary>
		[EnumMember(Value = "REQUIRES_SUPPORT")]
		RequiresSupport = 8
	}
}