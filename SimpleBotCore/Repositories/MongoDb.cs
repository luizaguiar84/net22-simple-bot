using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleBotCore.Repositories
{
    public class MongoDb : IMongoDb
    {
        private const string ConnectionString = "mongodb://localhost:27017";
        private const string database = "net2022";
        private const string collection = "simpleBot";

        public void Insert(BsonDocument doc)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(database);
            var col = db.GetCollection<BsonDocument>(collection);

            col.InsertOne(doc);
        }
    }
}
