using PropertyChanged;
using System;

namespace TekConf.ViewModels.Data
{
	[ImplementPropertyChanged]
	public class ConferenceListModel
	{
		public string Name { get; set; }

		public DateTime? Start { get; set; }

		public DateTime? End { get; set; }
	}
}