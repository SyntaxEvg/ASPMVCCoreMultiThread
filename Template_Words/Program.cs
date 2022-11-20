// See https://aka.ms/new-console-template for more information
using Orders.DAL.Entities;
using Template_Words.Extension.FileInfos;
using Template_Words.Models.Reports;
using Template_Words.Services.Impl;
using Template_Words.Services.Interfaces;

Console.WriteLine("Hello, World!");
var tempData = new ProductCatalog()
{
    Name = "Каталог товара",
    Description = "Актуальный список",
    CreateDate = DateTime.Now,
    Products = new List<Product>() 
    { new Product() {
        Id = 1,
        Name = "Bank1",
        Category = "Many",
        Price = 87323,
    },
    new Product() {
        Id = 2,
        Name = "Bank2",
        Category = "Many1",
        Price = 2323,
    }, 
    new Product() {
        Id = 3,
        Name = "Bank3",
        Category = "Many2",
        Price = 53123,
    },
    }
};

var tempFile = Environment.CurrentDirectory + @"\Templates\DefaultTemplate.docx";
if (File.Exists(tempFile))
{
    IproductReport prod = new ProductReportWord(tempFile);
    CreateReport(prod, tempData, "report" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5) + ".docx");
}
else
{
    throw new FileNotFoundException();
}


Console.ReadLine();

static void CreateReport(IproductReport iproductReport, ProductCatalog productCatalog,string reportFileName)
{
    iproductReport.CatalogName = productCatalog.Name;
    iproductReport.CatalogDescription = productCatalog.Description;
    iproductReport.CreateDate = productCatalog.CreateDate;
    iproductReport.Products = productCatalog.Products.Select(prod =>
                                                            (prod.Id, prod.Name, prod.Category, prod.Price))!;

    var reportfile =iproductReport.Create(reportFileName);
    if (reportfile.Exists)
    {
        reportfile.Execute(); 
      }


}