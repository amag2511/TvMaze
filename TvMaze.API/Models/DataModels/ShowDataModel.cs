using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TvMaze.API.DataModels
{
	[DataContract]
	public class ShowDataModel
	{

		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "url")]
		public string Url { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "type")]
		public string Type { get; set; }

		[DataMember(Name = "language")]
		public string Language { get; set; }

		[DataMember(Name = "genres")]
		public List<string> Genres { get; set; }

		[DataMember(Name = "status")]
		public string Status { get; set; }

		[DataMember(Name = "runtime")]
		public int Runtime { get; set; }

		[DataMember(Name = "premiered")]
		public string Premiered { get; set; }

		[DataMember(Name = "officialSite")]
		public string OfficialSite { get; set; }

		[DataMember(Name = "schedule")]
		public ScheduleDataModel Schedule { get; set; }

		[DataMember(Name = "rating")]
		public RatingDataModel Rating { get; set; }

		[DataMember(Name = "weight")]
		public int Weight { get; set; }

		[DataMember(Name = "network")]
		public NetworkDataModel Network { get; set; }

		[DataMember(Name = "webChannel")]
		public object WebChannel { get; set; }

		[DataMember(Name = "image")]
		public ImageDataModel Image { get; set; }

		[DataMember(Name = "summary")]
		public string Summary { get; set; }

		[DataMember(Name = "updated")]
		public int Updated { get; set; }

		[DataMember(Name = "_links")]
		public LinksDataModel Links { get; set; }

		[DataMember(Name = "_embedded")]
		public EmbeddedDataModel Embedded { get; set; }
	}
}
