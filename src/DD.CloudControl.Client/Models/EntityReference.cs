using Newtonsoft.Json;

namespace DD.CloudControl.Client.Models
{
	/// <summary>
	/// 	Represents reference to a CloudControl entry.
	/// </summary>
	public class EntityReference
	{
		/// <summary>
		/// 	The entity Id.
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 	The entity name.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}