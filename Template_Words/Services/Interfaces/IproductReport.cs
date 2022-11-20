using Orders.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Words.Services.Interfaces
{
    public interface IproductReport
    {
         FileInfo Create(string reportTemplate);
         string CatalogName { get; set; } 
         string CatalogDescription { get; set; }
         DateTime CreateDate { get; set; }
         IEnumerable<(int id,string name, string category,decimal price)> Products { get; set; }
    }
}
