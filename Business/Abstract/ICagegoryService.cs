using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICagegoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetByID(int categoryId);
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Detele(Category category);
    }
}
