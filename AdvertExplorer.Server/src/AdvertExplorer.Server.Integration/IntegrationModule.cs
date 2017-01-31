using AdvertExplorer.Server.Domain.Services;
using AdvertExplorer.Server.Integration.ZarplataRu;
using Autofac;
using AutoMapper;

namespace AdvertExplorer.Server.Integration
{
	public sealed class IntegrationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			Mapper.Initialize(x => x.AddProfile<IntegrationAutoMapperProfile>());
			builder.RegisterType<ZarplataRuApiClient>().As<IExternalResumeApiClient>().SingleInstance();
		}
	}
}