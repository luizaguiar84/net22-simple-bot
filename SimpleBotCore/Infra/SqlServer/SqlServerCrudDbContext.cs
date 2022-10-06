using Microsoft.EntityFrameworkCore;
using SimpleBotCore.Infra.Context;

namespace SimpleBotCore.Infra.SqlServer
{
    internal class SqlServerCrudDbContext : CrudDbContext
    {
        public SqlServerCrudDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
