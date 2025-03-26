using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var item in productManager.GetByStock(10,18))
            {
                Console.WriteLine($"Adi:{item.ProductName} - Qiymeti:{item.UnitPrice} - Sayi:{item.UnitsInStock}");
            }
        }
    }
}
