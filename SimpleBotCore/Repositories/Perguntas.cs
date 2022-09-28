using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleBotCore.Repositories
{
    public class Perguntas : IPerguntas
    {
        public string Perguntar(string pergunta)
        {
            var doc = new BsonDocument()
            {
                { "Pergunta", pergunta }
            };

            Insert(doc);

            return string.Empty;
        }

        private void Insert(BsonDocument doc)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("net2022");
            var col = db.GetCollection<BsonDocument>("simpleBot");

            col.InsertOne(doc);
        }
    }
}
