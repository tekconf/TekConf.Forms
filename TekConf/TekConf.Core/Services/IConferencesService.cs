using System.Threading.Tasks;
using System.Collections.Generic;
using Fusillade;
using TekConf.Core.Data.Dtos;

namespace TekConf.Core
{
	public interface IConferencesService
	{
		Task<List<ConferenceDto>> GetConferences(Priority priority);
		Task<List<ConferenceDto>> GetMyConferences(Priority priority);
		Task<ConferenceDto> GetConference(Priority priority, string slug);
	}
}