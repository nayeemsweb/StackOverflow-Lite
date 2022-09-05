using Autofac;
using StackOverflow.Infrastructure.DbContexts;
using StackOverflow.Infrastructure.Repositories;
using StackOverflow.Infrastructure.Services;
using StackOverflow.Infrastructure.UnitOfWorks;

namespace StackOverflow.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InfrastructureModule(string connectionString,
            string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<StackOverflowUnitOfWork>().As<IStackOverflowUnitOfWork>()
                .InstancePerLifetimeScope();

            //Post
            builder.RegisterType<PostRepository>().As<IPostRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<PostService>().As<IPostService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
