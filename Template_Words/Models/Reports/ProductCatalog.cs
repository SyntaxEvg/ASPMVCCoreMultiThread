using Orders.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Words.Models.Reports
{
    public class ProductCatalog 
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
