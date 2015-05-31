using System.Diagnostics;
using System;

namespace TekConf.Infrastructure
{

	public static class AsyncErrorHandler
	{
		public static void HandleException(Exception exception)
		{
			Debug.WriteLine(exception.Message);
		}
	}
}