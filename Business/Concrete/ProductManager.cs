using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICagegoryService _cagegoryService;

        public ProductManager(IProductDal productDal, ICagegoryService cagegoryService)
        {
            _productDal = productDal;
            _cagegoryService = cagegoryService;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCurrent(product.CategoryID),
                    CheckIfProductNameExixts(product.ProductName),
                    ChectCategoryLimite());
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }

        public IResult Delete(Product product)
        {
            throw new NotImplementedException();
        }
        #region Emeliyyatlar
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MintenanceTime);
            }
            return new SuccessDateResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new SuccessDateResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == id), Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDateResult<Product>(_productDal.Get(p => p.ProductID == productId), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetByStock(int min, int max)
        {
            return new SuccessDateResult<List<Product>>(_productDal.GetAll(p =>
            p.UnitsInStock > min && p.UnitsInStock <= max), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDateResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice > min
            && p.UnitPrice <= max), Messages.ProductsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDateResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), Messages.ProductsListed);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        #endregion
        private IResult CheckIfProductCountOfCategoryCurrent(int categoryID)
        {
            var result = _productDal.GetAll(p => p.CategoryID == categoryID).Count();
            if (result > 23)
            {
                return new ErrorResult(Messages.ProductCategoryCount);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExixts(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductCopyName);
            }
            return new SuccessResult();
        }
        private IResult ChectCategoryLimite()
        {
            var result = _cagegoryService.GetAll().Data.Count;
            if (result > 15)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
