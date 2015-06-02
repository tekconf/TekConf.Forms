using AutoMapper;
using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using TekConf.Core.Data.Repositories;
using TekConf.Core.Data.Models;
using TekConf.Core.ViewModels;
using TekConf.Core.Services;

namespace TekConf.Core.Infrastructure
{
	public static class Bootstrapper
	{
		public static void Init()
		{
			Mapper.CreateMap<ConferenceModel, ConferenceListModel> ();

			MvxSimpleIoCContainer.Initialize();

			Mvx.RegisterType<IConferenceRepository, ConferenceRepository> ();
			Mvx.RegisterType<IApiService, ApiService> ();
			Mvx.RegisterType<IConferencesService, ConferencesService> ();
		}
	}
}