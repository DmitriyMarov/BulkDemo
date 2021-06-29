using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkDeleteDemo
{
    class ClientToEntitiesConfiguration : EntityTypeConfiguration<ClientToEntities>
    {
        public ClientToEntitiesConfiguration()
        {
            ToTable("clienttoentities");
            HasKey(x => new { x.Client_Id, x.Entity_Id });

            Property(x => x.Client_Id).HasColumnName("client_id").IsRequired();
            Property(x => x.Entity_Id).HasColumnName("entity_id").IsRequired();
            Property(x => x.Excluded).HasColumnName("excluded").IsRequired();
            Property(x => x.ModifiedOn).HasColumnName("modifiedon").IsRequired();
            Property(x => x.AssociationKind).HasColumnName("associationkind").IsRequired();

            HasRequired(a => a.Client).WithMany(b => b.ClientToEntities).HasForeignKey(c => c.Client_Id).WillCascadeOnDelete(true);
            HasRequired(a => a.Entity).WithMany(b => b.ClientToEntities).HasForeignKey(c => c.Entity_Id).WillCascadeOnDelete(true);
        }
    }
}
