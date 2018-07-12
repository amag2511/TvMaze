using System.Runtime.Serialization;

namespace TvMaze.API.DataModels
{
	[DataContract]
	public class PersonDataModel
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "url")]
		public string Url { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "country")]
		public CountryDataModel Country { get; set; }

		[DataMember(Name = "birthday")]
		public string Birthday { get; set; }

		[DataMember(Name = "deathday")]
		public string Deathday { get; set; }

		[DataMember(Name = "gender")]
		public string Gender { get; set; }

		[DataMember(Name = "image")]
		public ImageDataModel Image { get; set; }

		[DataMember(Name = "_links")]
		public LinksDataModel Links { get; set; }
	}
}
