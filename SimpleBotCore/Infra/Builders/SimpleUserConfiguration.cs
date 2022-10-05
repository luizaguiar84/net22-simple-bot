using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBotCore.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBotCore.Infra.Builders
{
    internal class SimpleUserConfiguration : IEntityTypeConfiguration<SimpleUser>
    {
        public void Configure(EntityTypeBuilder<SimpleUser> builder)
        {
            builder.ToTable("SimpleUser");
            builder.HasKey(l => l.Id);            
        }
    }
}
