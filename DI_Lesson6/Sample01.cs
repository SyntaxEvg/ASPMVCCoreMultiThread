using Microsoft.EntityFrameworkCore;
using Orders.DAL.OrderDB;

namespace DI_Lesson6
{
    internal class Sample01
    {
        static void Main(string[] args)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<OrdersDBContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrdersDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
           
            using var context =new OrdersDBContext(dbContextOptionsBuilder.Options);
            context.Database.EnsureCreated();
            if(!context.Buyers.Any())
            {
                context.Buyers.Add(new Orders.DAL.Entities.Buyers()
                {
                    LastName ="Test1",
                    Patronymic = "Test1_Patronymic",
                    Name ="Adminc",
                    Birthday =DateTime.Now.AddYears(-30),
                });
                context.Buyers.Add(new Orders.DAL.Entities.Buyers()
                {
                    LastName ="Test2",
                    Patronymic = "Test2_Patronymic",
                    Name ="User1",
                    Birthday =DateTime.Now.AddYears(-38),
                });
                context.SaveChanges();
                foreach (var item in context.Buyers)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            

        }
    }
}