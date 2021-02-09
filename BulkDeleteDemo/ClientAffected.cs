using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkDeleteDemo
{
    public class ClientAffected
    {
        public int Id { get; set; }
        public int Client_Id { get; set; }

        public Client Client { get; set; }
    }
}
