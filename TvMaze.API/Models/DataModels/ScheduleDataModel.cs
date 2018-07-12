using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TvMaze.API.DataModels
{
	[DataContract]
	public class ScheduleDataModel
	{
		[DataMember(Name = "time")]
		public string Time { get; set; }

		[DataMember(Name = "days")]
		public List<string> Days { get; set; }
	}
}
