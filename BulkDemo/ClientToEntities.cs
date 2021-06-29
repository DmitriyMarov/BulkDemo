using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkDeleteDemo
{
    public class ClientToEntities
    {
        public int Client_Id { get; set; }
        public int Entity_Id { get; set; }
        public bool Excluded { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public int AssociationKind { get; set; }

        public Client Client { get; set; }
        public Entity Entity { get; set; }
    }
}
