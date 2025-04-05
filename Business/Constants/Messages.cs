using Core.Entities.Concrete;
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
        public static string ProductCategoryCount = "bir cateqoridre en cox 10 mehsul ola biler";
        public static string ProductCopyName = "Eyni adda product elave etmek olmaz";
        public static string ProductNameAlreadyExists = "Bu adda mehsul movcuddur";
        public static string CategoryAdded = "Yeni category elave edildi";
        public static string CategoryUpdated = "Category yenilendi";
        public static string CategoryDeleted = "Categori silindi";
        public static string AuthorizationDenied = "sizin bu emeliyyata icazeniz yoxdur";
        public static string UserAdded = "Yeni user elave edildi";
        public static string UserRegistered="istifadecinin zaten qeydiyyati var";
        public static string UserNotFound="istifadeci tapilmadi";
        public static string PasswordError;
        public static string SuccessfulLogin="Uqurlu giris";
        public static string UserAlreadyExists;
        public static string AccessTokenCreated;
    }
}
