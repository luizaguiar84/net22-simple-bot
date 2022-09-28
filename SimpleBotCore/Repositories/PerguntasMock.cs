namespace SimpleBotCore.Repositories
{
    public class PerguntasMock : IPerguntas
    {
        public string Perguntar(string pergunta) => 
            "Pergunta Gravada com sucesso!";        
    }
}
