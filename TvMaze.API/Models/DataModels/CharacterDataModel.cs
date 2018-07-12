using System.Runtime.Serialization;

namespace TvMaze.API.DataModels
{
	[DataContract]
	public class CharacterDataModel
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "url")]
		public string Url { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "image")]
		public ImageDataModel Image { get; set; }

		[DataMember(Name = "_links")]
		public LinksDataModel Links { get; set; }
	}
}
