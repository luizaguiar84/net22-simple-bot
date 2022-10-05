using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleBotCore.Repositories
{
    public class MongoDb : IMongoDb
    {
        private readonly string ConnectionString = "mongodb://localhost:27017";
        private readonly string Database = "net2022";
        private readonly string Collection = "simpleBot";

        public MongoDb(string connectionString, string database, string collection)
        {
            ConnectionString = connectionString;
            Database = database;
            Collection = collection;
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
