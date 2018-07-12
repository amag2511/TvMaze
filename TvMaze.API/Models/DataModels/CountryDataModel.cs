using System.Runtime.Serialization;

namespace TvMaze.API.DataModels
{
	[DataContract]
	public class CountryDataModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "code")]
		public string Code { get; set; }

		[DataMember(Name = "timezone")]
		public string Timezone { get; set; }
	}
}
