using System.Runtime.Serialization;

namespace TvMaze.API.DataModels
{
	[DataContract]
	public class NetworkDataModel
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "country")]
		public CountryDataModel Country { get; set; }
	}
}
