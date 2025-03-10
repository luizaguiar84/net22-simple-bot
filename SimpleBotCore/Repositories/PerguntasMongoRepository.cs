﻿using MongoDB.Bson;
using SimpleBotCore.Infra.MongoDb;
using SimpleBotCore.Repositories.Interfaces;

namespace SimpleBotCore.Repositories
{
    public class PerguntasMongoRepository : IPerguntas
    {
        private readonly IMongoDb _mongoDb;

        public PerguntasMongoRepository(IMongoDb mongoDb)
        {
            this._mongoDb = mongoDb;
        }
        public string Perguntar(string pergunta)
        {
            var doc = new BsonDocument()
            {
                { "Pergunta", pergunta }
            };

            _mongoDb.Insert(doc);

            return string.Empty;
        }
    }
}