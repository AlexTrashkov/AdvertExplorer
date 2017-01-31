using AdvertExplorer.Server.Domain.Services;
using AdvertExplorer.Server.Domain.Services.Implementations;
using Autofac;

namespace AdvertExplorer.Server.Domain
{
	public sealed class DomainModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ResumeService>().As<IResumeService>().SingleInstance();
		}
	}
}