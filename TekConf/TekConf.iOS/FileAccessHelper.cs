using System;
using TekConf.Infrastructure;

namespace TekConf.iOS
{
	public class FileAccessHelper : IFileAccessHelper
	{
		public string GetLocalFilePath()
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = System.IO.Path.Combine(docFolder, "..", "Library");

			if (!System.IO.Directory.Exists(libFolder)) {
				System.IO.Directory.CreateDirectory(libFolder);
			}

			return System.IO.Path.Combine(libFolder, "tekconf.db3");	
		}
	}
}