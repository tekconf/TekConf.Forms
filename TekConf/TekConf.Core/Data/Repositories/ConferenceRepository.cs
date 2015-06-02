using System;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using TekConf.Core.Infrastructure;
using TekConf.Core.Data.Models;

namespace TekConf.Core.Data.Repositories
{
	public class ConferenceRepository : IConferenceRepository
	{
		private readonly SQLiteAsyncConnection _connection;

		public ConferenceRepository (IFileAccessHelper fileAccessHelper)
		{
			var databasePath = fileAccessHelper.GetLocalFilePath ();
			_connection = new SQLiteAsyncConnection (databasePath);
			_connection.CreateTableAsync<ConferenceModel> ().Wait ();
		}

		public async Task AddAsync (ConferenceModel conference)
		{
			var result = await _connection.InsertAsync (conference);
		}

		public async Task<List<ConferenceModel>> GetAllAsync ()
		{
			return await _connection.Table<ConferenceModel> ().ToListAsync ();
		}
	}
}