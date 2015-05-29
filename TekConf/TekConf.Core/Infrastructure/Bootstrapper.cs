using AutoMapper;
using TekConf.Core;
using TekConf.ViewModels.Data;

namespace TekConf.Infrastructure
{
	public static class Bootstrapper
	{
		public static void Init()
		{
			Mapper.CreateMap<ConferenceModel, ConferenceListModel> ();
		}
	}
}