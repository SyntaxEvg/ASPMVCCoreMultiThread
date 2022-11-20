using Orders.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Words.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(int id, string addres, string phone, IEnumerable<(int productID, int quantity)> products);
    }
}
