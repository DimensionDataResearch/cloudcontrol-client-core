using System.Xml.Serialization;

namespace DD.CloudControl.Client.Models.Directory
{
	/// <summary>
	///     Represents a CloudControl access-control role.
	/// </summary>
	[XmlRoot("Role", Namespace = XmlNamespaces.Directory)]
	public class Role
	{
		/// <summary>
		///		Create a new CaaS role data-contract.
		/// </summary>
		public Role()
		{
		}

		/// <summary>
		///		The name of the CaaS role.
		/// </summary>
		[XmlElement("name", Namespace = XmlNamespaces.Directory)]
		public string Name { get; set; }

		/// <summary>
		///     A <see cref="RoleType"/> value representing the role.
		/// </summary>
		public RoleType RoleType
		{
			get
			{
				if (Name == null)
					return RoleType.Unknown;

				switch (Name)
				{
					case "backup":
					{
						return RoleType.Backup;
					}
					case "create image":
					{
						return RoleType.CreateImage;
					}
					case "network":
					{
						return RoleType.Network;
					}
					case "read only":
					{
						return RoleType.ReadOnly;
					}
					case "reports":
					{
						return RoleType.Reports;
					}
					case "server":
					{
						return RoleType.Server;
					}
					case "storage":
					{
						return RoleType.Storage;
					}
					case "tag":
					{
						return RoleType.Tag;
					}
					default:
					{
						return RoleType.Unknown;
					}
				}
			}
		}
	}
}