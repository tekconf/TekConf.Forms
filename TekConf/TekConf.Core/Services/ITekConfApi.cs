using System;
using Refit;
using System.Threading.Tasks;
using System.Collections.Generic;
using TekConf.Core.Data.Dtos;

namespace TekConf.Core.Services
{
	[Headers("Accept: application/json")]
	public interface ITekConfApi  
	{
		[Get("/conferences?showPastConferences=true")]
		Task<List<ConferenceDto>> GetConferences();

		[Get("/conferences?showPastConferences=true")]
		Task<List<ConferenceDto>> GetMyConferences();

		[Get("/conferences/{slug}")]
		Task<ConferenceDto> GetConference(string slug);
	}
}