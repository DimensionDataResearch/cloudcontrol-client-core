using System.Xml.Serialization;

namespace DD.CloudControl.Client.Models
{
	/// <summary>
	/// 	Represents the generic response returned by the CloudControl v1.x API when no more specific response is required / available.
	/// </summary>
	[XmlRoot("Status", Namespace = XmlNamespaces.Organization)]
	public class ApiResponseV1
	{
		/// <summary>
		/// 	The operation that the response relates to.
		/// </summary>
		[XmlElement("operation", Namespace = XmlNamespaces.Organization)]
		public string Operation { get; set; }

		/// <summary>
		/// 	The result of the operation that the response relates to.
		/// </summary>
		[XmlElement("result", Namespace = XmlNamespaces.Organization)]
		public string Result { get; set; }

		/// <summary>
		/// 	Detailed information about the result of the operation that the response relates to.
		/// </summary>
		[XmlElement("resultDetail", Namespace = XmlNamespaces.Organization)]
		public string ResultDetail { get; set; }

		/// <summary>
		/// 	The API result code.
		/// </summary>
		[XmlElement("resultCode", Namespace = XmlNamespaces.Organization)]
		public string ResultCode { get; set; }
	}
}