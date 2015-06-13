using System;
using System.Collections.Generic;
using Humanizer;

namespace TekConf.Core.Data.Dtos
{
	public class MyConferenceDto
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
	}
	
}