using System;
using Refit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TekConf.Core
{
	[Headers("Accept: application/json")]
	public interface ITekConfApi  
	{
		[Get("/conferences?showPastConferences=true")]
		Task<List<ConferenceDto>> GetConferences();

		[Get("/conferences/{slug}")]
		Task<ConferenceDto> GetConference(string slug);
	}
}

