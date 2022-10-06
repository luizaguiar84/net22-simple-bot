using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleBotCore.Infra.MongoDb
{
    public class MongoDb : IMongoDb
    {
        private readonly string ConnectionString;
        private readonly string Database;
        private readonly string Collection;

        public MongoDb(DatabaseConfiguration databaseConfiguration)
        {
            ConnectionString = databaseConfiguration.ConnectionString;
            Database = databaseConfiguration.Database;
            Collection = databaseConfiguration.Collection;
        }
        

        public void Insert(BsonDocument doc)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(Database);
            var col = db.GetCollection<BsonDocument>(Collection);

            col.InsertOne(doc);
        }
    }
}
