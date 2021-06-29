using Devart.Data.PostgreSql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace BulkDeleteDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Demo"].ConnectionString;
            var connection = new PgSqlConnection(connectionString);
            var context = new DemoDbContext(connection);

            var clientToCreate = new Client { Name = "test" };
            var clientToCreate1 = new Client { Name = "test" };
            context.Clients.Add(clientToCreate);
            context.Clients.Add(clientToCreate1);
            context.SaveChanges();
            try
            {               
                var result = context.Clients.WhereBulkContains(new List<Client> { clientToCreate }, mf => new { mf.Id }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
