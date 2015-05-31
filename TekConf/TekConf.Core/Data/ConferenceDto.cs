using System;
using Refit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TekConf.Core
{
	public class ConferenceDto
	{
		public string Name { get; set; }
		public string Slug { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public bool IsAddedToSchedule {get;set;}
		public bool? IsOnline { get; set; }

		public AddressDto Address { get; set; }
		public double[] Position { get; set; }

		public double Longitude { get; set; }
		public double Latitude { get; set; }

		string _imageUrlSquare;
		public string ImageUrlSquare {
			get {
				if (string.IsNullOrWhiteSpace(_imageUrlSquare))
				{
					return ImageUrl;
				}
				return _imageUrlSquare;
			}
			set {
				_imageUrlSquare = value;
			}
		}

		public List<SessionDto> Sessions { get; set; }
	}

}

