using AdvertExplorer.Server.Domain.Repositories;
using AdvertExplorer.Server.Storage.Repositories;
using Autofac;

namespace AdvertExplorer.Server.Storage
{
	public sealed class StorageModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<QueryRepository>().As<IQueryRepository>().SingleInstance();
			builder.RegisterType<ResumeRepository>().As<IResumeRepository>().SingleInstance();
		}

		public static void Main() { }   //HACK Entity Framework Core tools need entry point
	}
}