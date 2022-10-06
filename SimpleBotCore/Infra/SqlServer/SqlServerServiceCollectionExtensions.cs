using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleBotCore.Bot;
using SimpleBotCore.Infra;
using SimpleBotCore.Infra.Context;
using SimpleBotCore.Infra.SqlServer;
using SimpleBotCore.Logic;
using SimpleBotCore.Repositories;
using SimpleBotCore.Repositories.Interfaces;
using System.Reflection;

namespace SimpleBotCore.ExtensionMethods
{
    public static class SqlServerServiceCollectionExtensions
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

			services.AddTransient<IPerguntas, PerguntasSqlServerRepository>();
			services.AddSingleton<IUserProfileRepository>(new UserProfileMockRepository());
			services.AddTransient<IBotDialogHub, BotDialogHub>();
			services.AddTransient<BotDialog, SimpleBot>();

			return services;
		}
	}
}
