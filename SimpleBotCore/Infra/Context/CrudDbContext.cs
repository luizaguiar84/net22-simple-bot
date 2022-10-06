using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleBotCore.Entities;
using SimpleBotCore.Infra.Builders;
using SimpleBotCore.Logic;

namespace SimpleBotCore.Infra.Context
{
    public class CrudDbContext : DbContext
    {
        private IConfiguration _configuration;
        public DbSet<SimpleUser> SimpleUsers { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }

        public CrudDbContext(DbContextOptions dbContextOptions)
        {
            if (_configuration == null)
                _configuration = Startup.Configuration;
        }

        public CrudDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SimpleUserConfiguration());
            modelBuilder.ApplyConfiguration(new PerguntaConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_configuration[$"SqlServer.ConnectionString"]);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
