using Autofac;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Core.UseCases;

namespace Web.Api.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginAsyncUseCase>().As<ILoginAsyncUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<AddAsyncUserUseCase>().As<IAddAsyncUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetAsyncUsersUseCase>().As<IGetAsyncUsersUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetAsyncUserByIdUseCase>().As<IGetAsyncUserByIdUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateAsyncUserByIdUseCase>().As<IUpdateAsyncUserByIdUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<DeleteAsyncUserByIdUseCase>().As<IDeleteAsyncUserByIdUseCase>().InstancePerLifetimeScope();
        }
    }
}
