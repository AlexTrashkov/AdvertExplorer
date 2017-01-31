using AdvertExplorer.Server.Domain;
using AdvertExplorer.Server.Integration;
using AdvertExplorer.Server.Storage;
using Autofac;
using AutoMapper;

namespace AdvertExplorer.Server.Web
{
	public sealed class WebModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterModule<DomainModule>();
			builder.RegisterModule<IntegrationModule>();
			builder.RegisterModule<StorageModule>();

			Mapper.Initialize(x =>
			{
				x.AddProfile<StorageAutoMapperProfile>();
				x.AddProfile<IntegrationAutoMapperProfile>();
			});
			builder.RegisterInstance(Mapper.Instance).As<IMapper>().SingleInstance();
		}
	}
}