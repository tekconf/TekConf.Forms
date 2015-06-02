using System.Threading.Tasks;
using System.Collections.Generic;

namespace TekConf.Core.Data.Repositories
{
	public interface IConferenceRepository
	{
		Task AddAsync(ConferenceModel conference);
		Task<List<ConferenceModel>> GetAllAsync ();
	}
}