using System;
using System.Collections.Generic;
using Humanizer;

namespace TekConf.Core.Data.Dtos
{
	public class ConferenceDto
	{
		public string Name { get; set; }

		public string Slug { get; set; }

		public DateTime Start { get; set; }

		public DateTime End { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public bool IsAddedToSchedule { get; set; }

		public bool? IsOnline { get; set; }

		public AddressDto Address { get; set; }

		public double[] Position { get; set; }

		public double Longitude { get; set; }

		public double Latitude { get; set; }

		string _imageUrlSquare;

		public string ImageUrlSquare {
			get {
				return string.IsNullOrWhiteSpace (_imageUrlSquare) ? ImageUrl : _imageUrlSquare;
			}
			set {
				_imageUrlSquare = value;
			}
		}

		public List<SessionDto> Sessions { get; set; }


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

//		public string FormattedAddress
//		{
//			get
//			{
//				string formattedAddress;
//				if (IsOnline == true)
//				{
//					formattedAddress = "online";
//				}
//				else if (StreetNumber != default(int) && !string.IsNullOrWhiteSpace(StreetName) && !string.IsNullOrWhiteSpace(City) &&
//					!string.IsNullOrWhiteSpace(State))
//				{
//					formattedAddress = StreetNumber + " " + StreetName + "\n" + City + ", " + State + " " + PostalArea;
//				}
//				else if (!string.IsNullOrWhiteSpace(City) && !string.IsNullOrWhiteSpace(State))
//				{
//					formattedAddress = City + ", " + State;
//				}
//				else if (!string.IsNullOrWhiteSpace(City) && !string.IsNullOrWhiteSpace(Country))
//				{
//					formattedAddress = City + ", " + Country;
//				}
//				else if (!string.IsNullOrWhiteSpace(City))
//				{
//					formattedAddress = City;
//				}
//				else
//				{
//					formattedAddress = "No location set";
//				}
//
//				return formattedAddress;
//			}
//		}
	}
}