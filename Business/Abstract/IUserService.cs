using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Update(User rental);
        IResult Add(User rental);
        IResult Delete(User rental);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
    }
}
