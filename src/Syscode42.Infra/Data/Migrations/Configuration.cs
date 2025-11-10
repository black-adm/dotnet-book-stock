using Syscode42.Infra.Data.Context;
using System.Data.Entity.Migrations;

namespace Syscode42.Infra.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
