using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DD.CloudControl.Client.Models.Directory
{
	/// <summary>
	/// 	Represents information about a Cloud Control user account.
	/// </summary>
	[XmlRoot("Account", Namespace = XmlNamespaces.Directory)]
	public class UserAccount
	{
		/// <summary>
		///		Create a new <see cref="UserAccount"/>.
		/// </summary>
		public UserAccount()
		{
		}

		/// <summary>
		///		The user login name associated with the account.
		/// </summary>
		[XmlElement("userName")]
		public string UserName { get; set; }

		/// <summary>
		///		The full name of the user associated with the account.
		/// </summary>
		[XmlElement("fullName")]
		public string FullName { get; set; }

		/// <summary>
		///		The first name of the user associated with the account.
		/// </summary>
		[XmlElement("firstName")]
		public string FirstName { get; set; }

		/// <summary>
		///		The last name of the user associated with the account.
		/// </summary>
		[XmlElement("lastName")]
		public string LastName { get; set; }

		/// <summary>
		///		The e-mail address of the user associated with the account.
		/// </summary>
		[XmlElement("emailAddress")]
		public string EmailAddress { get; set; }

		/// <summary>
		///		The name of the department to which the account's user belongs.
		/// </summary>
		[XmlElement("department")]
		public string Department { get; set; }

		/// <summary>
		///		Custom field 1.
		/// </summary>
		[XmlElement("customDefined1")]
		public string CustomField1 { get; set; }

		/// <summary>
		///		Custom field 2.
		/// </summary>
		[XmlElement("customDefined2")]
		public string CustomField2 { get; set; }

		/// <summary>
		///		The Id of the organisation to which the account belongs.
		/// </summary>
		[XmlElement("orgId")]
		public Guid OrganizationId { get; set; }

		/// <summary>
		/// 	The user's password.
		/// </summary>
		[XmlElement("password")]
		public string Password { get; set; }

		/// <summary>
		///		Roles (if any) to which the account belongs.
		/// </summary>
		[XmlArray("roles")]
		[XmlArrayItem("role")]
		public List<Role> MemberOfRoles { get; set; } = new List<Role>();
	}
}
