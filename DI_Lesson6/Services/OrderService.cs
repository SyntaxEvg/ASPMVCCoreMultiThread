using DI_Lesson6.Services.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Orders.DAL.Entities;
using Orders.DAL.OrderDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Lesson6.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger _logger;
        private readonly OrdersDBContext _dBContext;

        public OrderService(OrdersDBContext dBContext, ILogger<OrderService> logger)
        {
            _dBContext = dBContext; _logger=logger;
        }

        public async Task<Order> CreateAsync(int id, string addres, string phone, IEnumerable<(int productID, int quantity)> products)
        {
            var buyer =await _dBContext.Buyers.FirstOrDefaultAsync(x=> x.Id == id);
            if (buyer is null)
            {
                throw new Exception("error buyers");
            }
            var dictProd =new Dictionary<Product, int>();
            foreach (var item in products)
            {
                var prod = await _dBContext.Product.FirstOrDefaultAsync(x => x.Id == id);
                if (prod is null)
                {
                    throw new Exception("error product");
                }
                if (dictProd.ContainsKey(prod))
                {
                    dictProd[prod] += item.quantity;
                }
            }
            var order = new Order()
            {
                Buyers = buyer,
                Adress = addres,
                Phone = phone,
                Items = dictProd.Select(x => new OrderItem()
                {
                    Product = x.Key,
                    Quantity = x.Value,
                }).ToArray()

            };
            await _dBContext.Order.AddAsync(order);
            await _dBContext.SaveChangesAsync();


            return order;
        }   
    }
}
