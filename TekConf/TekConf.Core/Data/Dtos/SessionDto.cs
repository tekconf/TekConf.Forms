using System;
using System.Collections.Generic;

namespace TekConf.Core.Data.Dtos
{
	public class SessionDto
	{
		public string Slug { get; set; }

		public string Title { get; set; }

		public DateTime Start { get; set; }

		public DateTime End { get; set; }

		public string Room { get; set; }

		public string Difficulty { get; set; }

		public string Description { get; set; }

		public string TwitterHashTag { get; set; }

		public string SessionType { get; set; }

		public bool IsAddedToSchedule { get; set; }

		public List<SpeakerDto> Speakers { get; set; }

		public string Date
		{
			get {
				string range;
				if (Start == default(DateTime) || End == default(DateTime)) {
					range = "No Date Set";
				} else if (Start.Month == End.Month && Start.Year == End.Year) {
					// They begin and end in the same month
					if (Start.Date == End.Date) {
						range = Start.ToString ("MMMM") + " " + Start.Day + ", " + Start.Year;
					} else
						range = Start.ToString ("MMMM") + " " + Start.Day + " - " + End.Day + ", " + Start.Year;
				} else {
					// They begin and end in different months
					if (Start.Year == End.Year) {
						range = Start.ToString ("MMMM") + " " + Start.Day + " - " + End.ToString ("MMMM") + " " + End.Day + ", " + Start.Year;
					} else {
						range = Start.ToString ("MMMM") + " " + Start.Day + ", " + Start.Year + " - " + End.ToString ("MMMM") + " " + End.Day + ", " + End.Year;
					}

				}

				return range;
			}
		}
	}
}