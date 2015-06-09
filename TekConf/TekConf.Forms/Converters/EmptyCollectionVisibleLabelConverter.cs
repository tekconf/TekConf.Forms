using System;
using Xamarin.Forms;
using System.Collections;
using System.Linq;
using System.Collections.ObjectModel;
using TekConf.Core.Data.Dtos;

namespace TekConf.Forms.Converters
{
	public class EmptyCollectionVisibleLabelConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var collection = (ObservableCollection<ConferenceDto>)value;
			if (collection != null) {
				return !collection.Any ();
			} else {
				return true;
			}
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
	}

	public class EmptyCollectionInvisibleLabelConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var collection = (ObservableCollection<ConferenceDto>)value;
			if (collection != null) {
				return collection.Any ();
			} else {
				return false;
			}
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
	}
	
}