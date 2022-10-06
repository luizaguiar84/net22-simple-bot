using Microsoft.Extensions.Configuration;
using System;

namespace SimpleBotCore.Infra
{

    public class DatabaseConfiguration
    {
        public string ConnectionStringName { get; }
        public string ConnectionString { get; }
        public string Database { get; }
        public string Collection { get; }

        public DatabaseType DbType { get; }

        public DatabaseConfiguration(IConfiguration configuration)
        {
            ConnectionStringName = configuration["DefaultConnectionString"];


            if (DatabaseType.MongoDb.ToString().Equals(ConnectionStringName, StringComparison.CurrentCultureIgnoreCase))
            {
                DbType = DatabaseType.MongoDb;
                Database = configuration[$"MongoDb.Database"];
                Collection = configuration[$"MongoDb.Collection"];
            }

            else if (DatabaseType.SqlServer.ToString().Equals(ConnectionStringName, StringComparison.CurrentCultureIgnoreCase))
            {
                DbType = DatabaseType.SqlServer;
            }

            else
            {
                throw new NotSupportedException($"Invalid ConnectionString name '{ConnectionStringName}'.");
            }

            ConnectionString = configuration[$"{ConnectionStringName}.ConnectionString"];
        }

        public enum DatabaseType
        {
            MongoDb,
            SqlServer
        }
    }
}