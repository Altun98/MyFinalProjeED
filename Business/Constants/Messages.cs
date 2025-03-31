using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Yeni mehsul elave edildi";
        public static string ProductUpdated = "Mehsul melumatlari yenilendi";
        public static string ProductDeleted = "Mehsul silindi";
        public static string ProductNameInvalid = "Mehsul adi minimum 2 herf olmalidir";
        public static string ProductsListed = "Mehsullar listelendi";
        public static string MintenanceTime = "Sistem uzerinde is zamani";
        public static string ProductPriceInvalid = "Mehsulun qiymeti 0 ola bilmez";
    }
}
