using System;
using TekConf.Infrastructure;
using TekConf.Core.Infrastructure;

namespace TekConf.Droid
{
	public class FileAccessHelper : IFileAccessHelper
	{
		public string GetLocalFilePath ()
		{
			string path = System.Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			return System.IO.Path.Combine (path, "tekconf.db3");
		}
	}
}