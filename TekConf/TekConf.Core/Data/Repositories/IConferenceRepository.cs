using System.Threading.Tasks;
using System.Collections.Generic;
using TekConf.Core.Data.Models;

namespace TekConf.Core.Data.Repositories
{
	public interface IConferenceRepository
	{
		Task AddAsync(ConferenceModel conference);
		Task<List<ConferenceModel>> GetAllAsync ();
	}
}