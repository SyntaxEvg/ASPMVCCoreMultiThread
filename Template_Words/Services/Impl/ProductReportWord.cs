using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template_Words.Services.Interfaces;
using TemplateEngine.Docx;

namespace Template_Words.Services.Impl
{
    public class ProductReportWord : IproductReport
    {
        string _FieldCatalogName = "CatalogName";
        string _FieldCatalogDescription = "CatalogDescription";
        string _FieldCreationDate = "CreationDate";

        //Product
        string _FieldProduct = "Product";
        string _FieldProductID = "ProductID";
        string _FieldProductName = "ProductName";
        string _FieldProductCategory = "ProductCategory";
        string _FieldProductPrice = "ProductPrice";
        string _FieldProductTotal = "ProductTotal";


        public string CatalogName { get; set; }
        public string CatalogDescription { get ; set ; }
        public DateTime CreateDate { get; set; }
        public IEnumerable<(int id, string name, string category, decimal price)> Products { get; set; }

        readonly FileInfo _tempate;

        public ProductReportWord(string tempate)
        {
            _tempate = new FileInfo(tempate);
        }

        public FileInfo Create(string reportTemplate)
        {
            if (!_tempate.Exists)
            { 
                throw new FileNotFoundException();
            }
            var reportFile =new FileInfo(reportTemplate);
            reportFile.Delete();
            _tempate.CopyTo(reportFile.FullName);
           

            var rowProduct =Products.Select(prod => new TableRowContent(new List<FieldContent>()
            {
                new FieldContent(_FieldProductID, prod.id.ToString()),
                new FieldContent(_FieldProductName, prod.name.ToString()),
                new FieldContent(_FieldProductCategory, prod.category.ToString()),
                new FieldContent(_FieldProductPrice, prod.price.ToString()),
            
            }
            )).ToArray();

            var content = new Content(
               new FieldContent(_FieldCatalogName, "Template ok!!!"),
               new FieldContent(_FieldCreationDate, DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss")),
               TableContent.Create(_FieldProduct, rowProduct),
               new FieldContent(_FieldProductTotal,Products.Sum(P => P.price).ToString("c"))
               );

            var tempateProcess = new TemplateProcessor(reportFile.FullName).SetRemoveContentControls(true);
            tempateProcess.FillContent(content);
            tempateProcess.SaveChanges();
            reportFile.Refresh();
            return reportFile;

        }
    }
}
