using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICagegoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDateResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetByID(int categoryId)
        {
            return new SuccessDateResult<Category>(_categoryDal.Get(p => p.CategoryID == categoryId));
        }
    }
}
