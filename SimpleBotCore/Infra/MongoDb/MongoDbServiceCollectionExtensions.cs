using Microsoft.Extensions.DependencyInjection;
using SimpleBotCore.Bot;
using SimpleBotCore.Logic;
using SimpleBotCore.Repositories;
using SimpleBotCore.Repositories.Interfaces;

namespace SimpleBotCore.Infra.MongoDb
{
    public static class MongoDbServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDbDependency(this IServiceCollection services, DatabaseConfiguration configuration)
        {
            services.AddSingleton<IMongoDb>(new MongoDb(configuration));
            services.AddSingleton<IPerguntas, PerguntasMongoRepository>();
            services.AddSingleton<IUserProfileRepository>(new UserProfileMockRepository());
            services.AddSingleton<IBotDialogHub, BotDialogHub>();
            services.AddSingleton<BotDialog, SimpleBot>();

            return services;
        }
    }
}
