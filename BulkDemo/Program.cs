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

            var clientToCreate = new Client { Name = "test" };
            try
            {
                context.BulkInsert<Client>(new List<Client> { clientToCreate }, options =>
                {
                    options.AutoMapOutputDirection = true;
                    options.InsertIfNotExists = true;
                    options.BatchSize = 100;
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
