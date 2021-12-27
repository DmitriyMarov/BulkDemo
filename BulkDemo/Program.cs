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

            var clientToCreate = new Client { Name = "test1" };
            var clientToCreate1 = new Client { Name = "test2" };
            context.Clients.Add(clientToCreate);
            context.Clients.Add(clientToCreate1);
            context.SaveChanges();
            try
            {
                var selectDbSet = context.Set<Client>().AsNoTracking();
                var result = selectDbSet.WhereBulkContains(new List<Client> { clientToCreate }, mf => new { mf.Name }).ToList();
                var itemsToRemove = context.Clients.ToList();
                if (!itemsToRemove.Any())
                {
                    return;
                }

                foreach (var item in itemsToRemove)
                {
                    context.Clients.Remove(item);
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
