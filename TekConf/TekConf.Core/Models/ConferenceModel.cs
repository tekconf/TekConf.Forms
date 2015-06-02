using System;
using SQLite;

namespace TekConf.Core.Data.Models
{
	[Table("Conferences")]
	public class ConferenceModel
	{
		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id { get; set; }

		[Unique]
		public string Slug { get; set; }

		public string Name { get; set; }

		public DateTime? Start { get; set; }

		public DateTime? End { get; set; }

		public DateTime? CallForSpeakersOpens { get; set; }

		public DateTime? CallForSpeakersCloses { get; set; }

		public DateTime? RegistrationOpens { get; set; }

		public DateTime? RegistrationCloses { get; set; }

		public DateTime? LastUpdated { get; set; }

		public string ImageUrl { get; set; }

		public string HomepageUrl { get; set; }

		public int? DefaultTalkLength { get; set; }

		public int? NumberOfSessions { get; set; }

		public bool? IsLive { get; set; }

		public bool? IsAddedToSchedule { get; set; }

		public string DateRange { get; set; }

		public string FormattedAddress { get; set; }

		public string FacebookUrl { get; set; }

		public string TwitterName { get; set; }

		public string Description { get; set; }

		public string Location { get; set; }

		public string ImageUrlSquare { get; set; }

		public string TwitterHashTag { get; set; }

		public bool? IsOnline { get; set; }

		public string GooglePlusUrl { get; set; }

		public string Tagline { get; set; }

		public string LinkedInUrl { get; set; }

		public string LanyrdUrl { get; set; }

		public string YoutubeUrl { get; set; }

		public string GithubUrl { get; set; }

		public string VimeoUrl { get; set; }

		public int? StreetNumber { get; set; }

		public string City { get; set; }

		public string Country { get; set; }

		public string State { get; set; }

		public string StreetName { get; set; }

		public string PostalArea { get; set; }

		public double? Latitude {get;set;}

		public double? Longitude {get;set;}

//		public List<double?> Position { get; set; }
//
//		public List<object> Rooms { get; set; }
//
//		public List<object> SessionTypes { get; set; }
//
//		public List<object> Subjects { get; set; }
//
//		public List<object> Tags { get; set; }
//
//		public List<object> Sessions { get; set; }
	}
}