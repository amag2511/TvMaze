using System.Runtime.Serialization;

namespace TvMaze.API.DataModels
{
	[DataContract]
	public class RatingDataModel
	{
		[DataMember(Name = "average")]
		public double Average { get; set; }
	}
}
