using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkDeleteDemo
{
    public class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ClientToEntities> ClientToEntities { get; set; }
    }
}
