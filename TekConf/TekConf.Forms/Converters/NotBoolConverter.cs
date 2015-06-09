using System;
using Xamarin.Forms;
using System.Collections;
using System.Linq;
using System.Collections.ObjectModel;
using TekConf.Core.Data.Dtos;

namespace TekConf.Forms.Converters
{
	public class NotBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool && (bool)value)
				return false;
			else
				return true;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool && (bool)value)
				return false;
			else
				return true;
		}
	}
}