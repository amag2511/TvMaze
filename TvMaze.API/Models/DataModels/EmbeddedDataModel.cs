using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TvMaze.API.DataModels
{
	[DataContract]
	public class EmbeddedDataModel
	{
		[DataMember(Name = "cast")]
		public List<CastDataModel> Cast { get; set; }
	}
}