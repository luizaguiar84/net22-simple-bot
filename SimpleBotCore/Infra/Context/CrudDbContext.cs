﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleBotCore.Infra.Builders;
using SimpleBotCore.Logic;

namespace SimpleBotCore.Infra.Context
{
    public class CrudDbContext : DbContext
	{
		private readonly IConfiguration _configuration;
		public DbSet<SimpleUser> Lead { get; set; }
		public CrudDbContext(DbContextOptions dbContextOptions)
		{ }

		public CrudDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
		{
			_configuration = configuration;
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new SimpleUserConfiguration());

			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServer"));
			}
			base.OnConfiguring(optionsBuilder);
		}
	}
}
