using AutoMapper;
using TekConf.Core;
using TekConf.ViewModels.Data;
using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;

namespace TekConf.Infrastructure
{
	public static class Bootstrapper
	{
		public static void Init()
		{
			Mapper.CreateMap<ConferenceModel, ConferenceListModel> ();

			MvxSimpleIoCContainer.Initialize();
			Mvx.RegisterType<IConferenceRepository, ConferenceRepository> ();
		}
	}
}