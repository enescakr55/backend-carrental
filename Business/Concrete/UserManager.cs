using Business.Abstract;
using Business.Constants;
using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userdal)
        {
            _userDal = userdal;
        }
        public IResult Add(User rental)
        {
            _userDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User rental)
        {
            _userDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(c=>c.Id == id));
        }

        public IResult Update(User rental)
        {
            _userDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
