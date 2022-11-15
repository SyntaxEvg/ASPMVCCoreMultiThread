using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orders.DAL.OrderDB;

namespace DI_Lesson6
{
    internal class Sample02
    {
        static void Main(string[] args)
        {
            var serviceBuilder = new ServiceCollection();

            serviceBuilder.AddDbContext<OrdersDBContext>(opt => opt.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrdersDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
           // serviceBuilder.AddScoped<IOrdersDBContext, OrdersDBContext>
          
            var services = serviceBuilder.BuildServiceProvider();
            var context = services.GetRequiredService<OrdersDBContext>();
            foreach (var item in context.Buyers)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}