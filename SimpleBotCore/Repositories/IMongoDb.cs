using MongoDB.Bson;

namespace SimpleBotCore.Repositories
{
    public interface IMongoDb
    {
        void Insert(BsonDocument doc);
    }
}