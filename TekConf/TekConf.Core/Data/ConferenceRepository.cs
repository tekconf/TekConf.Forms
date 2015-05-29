using System;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using TekConf.Infrastructure;

namespace TekConf.Core
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
			try {
				var result = await _connection.InsertAsync (conference);
			} catch (Exception ex) {
			}
		}

		public async Task<List<ConferenceModel>> GetAllAsync ()
		{
			return await _connection.Table<ConferenceModel> ().ToListAsync ();
		}
	}
}

