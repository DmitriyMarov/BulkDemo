using Devart.Data.PostgreSql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkDeleteDemo
{
    public class DemoDbContext : DbContext
    {

        protected string Schema => "public";

        public IDbSet<ClientAffected> ClientAffected { get; set; }

        public IDbSet<Client> Clients { get; set; }

        public DemoDbContext(PgSqlConnection connection) : base(connection, true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(this.Schema);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ClientAffectedConfiguration());
            modelBuilder.Configurations.Add(new ClientConfiguration());
        }
    }
}
