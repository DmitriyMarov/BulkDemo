using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkDeleteDemo
{
    class ClientAffectedConfiguration : EntityTypeConfiguration<ClientAffected>
    {
        public ClientAffectedConfiguration()
        {
            ToTable("clientaffected");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Client_Id).HasColumnName("client_id").IsRequired();

            HasRequired(a => a.Client).WithMany(b => b.ClientAffected).HasForeignKey(c => c.Client_Id).WillCascadeOnDelete(true);
        }
    }
}
