using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleBotCore.Bot;
using SimpleBotCore.ExtensionMethods;
using SimpleBotCore.Infra;
using SimpleBotCore.Infra.MongoDb;
using SimpleBotCore.Logic;
using SimpleBotCore.Repositories;
using SimpleBotCore.Repositories.Interfaces;

namespace SimpleBotCore
{
    public class Startup
    {
        public Infra.DatabaseConfiguration DatabaseConfiguration { get; }
        public static IConfiguration Configuration { get; set; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DatabaseConfiguration = new DatabaseConfiguration(configuration);

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            if (DatabaseConfiguration.DbType == DatabaseConfiguration.DatabaseType.SqlServer)
                services.AddSqlServerDependency(DatabaseConfiguration);

            else if (DatabaseConfiguration.DbType == DatabaseConfiguration.DatabaseType.MongoDb)
                services.AddMongoDbDependency(DatabaseConfiguration);


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
