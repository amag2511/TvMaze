using System.Runtime.Serialization;

namespace TvMaze.API.DataModels
{
	[DataContract]
	public class LinkDataModel
	{
		[DataMember(Name = "href")]
		public string Href { get; set; }
	}
}
