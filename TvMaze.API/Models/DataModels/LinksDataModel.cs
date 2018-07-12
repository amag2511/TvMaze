using System.Runtime.Serialization;

namespace TvMaze.API.DataModels
{
	[DataContract]
	public class LinksDataModel
    {
	    [DataMember(Name = "self")]
		public LinkDataModel Self { get; set; }

	    [DataMember(Name = "previousepisode")]
		public LinkDataModel PreviousEpisode { get; set; }

	    [DataMember(Name = "nextepisode")]
	    public LinkDataModel NextEpisode { get; set; }
	}
}
