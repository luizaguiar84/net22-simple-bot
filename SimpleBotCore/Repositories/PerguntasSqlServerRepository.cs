using SimpleBotCore.Entities;
using SimpleBotCore.Infra.Context;
using SimpleBotCore.Repositories.Interfaces;

namespace SimpleBotCore.Repositories
{
    public class PerguntasSqlServerRepository : IPerguntas
    {
        private readonly CrudDbContext _context;

        public PerguntasSqlServerRepository(CrudDbContext context)
        {
           _context = context;
        }

        public string Perguntar(string pergunta)
        {
            var entity = new Pergunta()
            {
                Perguntar = pergunta
            };

            _context.Perguntas.Add(entity);
            _context.SaveChanges();

            return pergunta;
        }
    }
}
