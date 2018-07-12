using System.Runtime.Serialization;

namespace TvMaze.API.DataModels
{
	[DataContract]
	public class ImageDataModel
	{
		[DataMember(Name = "medium")]
		public string Medium { get; set; }

		[DataMember(Name = "original")]
		public string Original { get; set; }
	}
}
