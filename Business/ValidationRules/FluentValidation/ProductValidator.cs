using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotNull().WithMessage("mehsulun adi bos ola bilmez");
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("Mehsulun adi 2 sinvoldan kicik ola bilez");
            RuleFor(p => p.UnitPrice).NotNull();
            RuleFor(p => p.UnitsInStock).NotNull();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1);
            RuleFor(p=>p.ProductName).Must(StartwithA);
        }
        private bool StartwithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
