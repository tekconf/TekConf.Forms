using System.Threading.Tasks;
using System.Collections.Generic;
using Fusillade;

namespace TekConf.Core
{
	public interface IConferencesService
	{
		Task<List<ConferenceDto>> GetConferences(Priority priority);
		Task<ConferenceDto> GetConference(Priority priority, string slug);
	}
}