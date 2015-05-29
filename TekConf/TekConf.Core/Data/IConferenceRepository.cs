using System;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TekConf.Core
{
	public interface IConferenceRepository
	{
		Task AddAsync(ConferenceModel conference);
		Task<List<ConferenceModel>> GetAllAsync ();
	}
	
}
