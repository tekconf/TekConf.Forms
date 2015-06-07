using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Cirrious.CrossCore;
using TekConf.Core.Infrastructure;
using TekConf.Pages;
using TekConf.Infrastructure;
using TwinTechs.Controls;

namespace TekConf.Forms
{
	public static class AppHelper
	{
		public static IFastCellCache FastCellCache { get; set; }

		public static Size ScreenSize { get; set; }
	}
	
}
