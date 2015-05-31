using System;
using Refit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TekConf.Core
{
	public class AddressDto
	{
		public int StreetNumber { get; set; }
		public string StreetName { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostalArea { get; set; }
		public string Country { get; set; }
	}

}
