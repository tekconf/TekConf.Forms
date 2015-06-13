using System.Threading.Tasks;
using System.Collections.Generic;
using Fusillade;
using TekConf.Core.Data.Dtos;

namespace TekConf.Core.Services
{
	public interface IConferencesService
	{
		Task<List<ConferenceDto>> GetConferences(bool force, Priority priority);
		Task<List<MyConferenceDto>> GetMyConferences(bool force, Priority priority);
		Task<ConferenceDto> GetConference(Priority priority, string slug);
		Task<MyConferenceDto> GetMyConference(Priority priority, string slug);
	}
}