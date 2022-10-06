using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBotCore.Entities;

namespace SimpleBotCore.Infra.Builders
{
    public class PerguntaConfiguration : IEntityTypeConfiguration<Pergunta>
    {
        public void Configure(EntityTypeBuilder<Pergunta> builder)
        {
            builder.ToTable("Perguntas");
            builder.HasKey(l => l.Id);
        }    
    }
}
