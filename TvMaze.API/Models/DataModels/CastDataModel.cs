using System.Runtime.Serialization;

namespace TvMaze.API.DataModels
{
	[DataContract]
	public class CastDataModel
	{
		[DataMember(Name = "person")]
		public PersonDataModel Person { get; set; }

		[DataMember(Name = "character")]
		public CharacterDataModel Character { get; set; }
	}
}
