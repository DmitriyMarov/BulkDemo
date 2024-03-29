﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkDeleteDemo
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ClientAffected> ClientAffected { get; set; }

        public ICollection<ClientToEntities> ClientToEntities { get; set; }
    }
}
