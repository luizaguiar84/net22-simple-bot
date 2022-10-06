using MongoDB.Bson;

namespace SimpleBotCore.Infra.MongoDb
{
    public interface IMongoDb
    {
        void Insert(BsonDocument doc);
    }
}