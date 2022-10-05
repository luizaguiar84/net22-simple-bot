using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleBotCore.Infra;
using SimpleBotCore.Infra.Context;
using SimpleBotCore.Infra.SqlServer;
using System.Reflection;

namespace SimpleBotCore.ExtensionMethods
{
    public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddSqlServerDependency(this IServiceCollection services, DatabaseConfiguration configuration)
		{
			services.AddDbContext<CrudDbContext, SqlServerCrudDbContext>(options =>
			{
				options.EnableSensitiveDataLogging();
				
				options.UseSqlServer(configuration.ConnectionString, options =>
				{
					options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
				});

			});


			return services;
		}
	}
}
