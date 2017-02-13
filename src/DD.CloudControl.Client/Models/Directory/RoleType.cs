using System.Xml.Serialization;

namespace DD.CloudControl.Client.Models.Directory
{
	/// <summary>
	///	 Well-known CloudControl role types.
	/// </summary>
	[XmlRoot("roleType", Namespace = XmlNamespaces.Directory)]
	public enum RoleType
	{
		/// <summary>
		///		An unknown role type.
		/// </summary>
		/// <remarks>
		///		Used to detect uninitialised values; do not use directly.
		/// </remarks>
		Unknown = 0,

		/// <summary>
		///		The backup role.
		/// </summary>
		[XmlEnum("backup")]
		Backup,

		/// <summary>
		///		The create image role.
		/// </summary>
		[XmlEnum("create image")]
		CreateImage,

		/// <summary>
		///		The network role.
		/// </summary>
		[XmlEnum("network")]
		Network,

		/// <summary>
		///		The read-only role.
		/// </summary>
		[XmlEnum("read only")]
		ReadOnly,

		/// <summary>
		///		The server role.
		/// </summary>
		[XmlEnum("server")]
		Server,

		/// <summary>
		///		The storage role.
		/// </summary>
		[XmlEnum("storage")]
		Storage,

		/// <summary>
		///		The reports role.
		/// </summary>
		[XmlEnum("reports")]
		Reports,

		/// <summary>
		///	 The tag role.
		/// </summary>
		[XmlEnum("tag")]
		Tag
	}
}
