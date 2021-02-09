using Devart.Data.PostgreSql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkDeleteDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Demo"].ConnectionString;
            var connection = new PgSqlConnection(connectionString);
            var context = new DemoDbContext(connection);
            var clientToCreate = new Client { Id = 1, Name = "test"};
            var clientAffectedToCreate = new ClientAffected { Id = 1, Client_Id = 1 };
            context.Clients.Add(clientToCreate);
            context.ClientAffected.Add(clientAffectedToCreate);
            context.SaveChanges();

            var clientAffectedToDelete = new ClientAffected { Client_Id = 1 };
            try
            {
                context.BulkDelete<ClientAffected>(new List<ClientAffected> { clientAffectedToDelete }, options =>
                {
                    options.ColumnPrimaryKeyExpression = u => u.Client_Id;
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
