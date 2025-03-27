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
            //  GetAllProduct();
            //   GetAllCategory();
            // GetAllProductDetails();
            Console.ReadLine();
        }

        private static void GetAllProductDetails()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var item in productManager.GetProductDetails())
            {
                Console.WriteLine($"Mehsul: {item.ProductName} ---- Catagory: {item.CategoryName}");
            }
           
        }

        private static void GetAllProduct()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            Console.WriteLine("-------------------------------------------------");
            foreach (var item in productManager.GetAll())
            {
                Console.WriteLine($"Adi:{item.ProductName} - Qiymeti:{item.UnitPrice} - Sayi:{item.UnitsInStock}");
            }
            Console.WriteLine("-------------------------------------------------");
        }

        private static void GetAllCategory()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }
    }
}
