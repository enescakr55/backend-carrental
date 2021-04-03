using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Web.Http;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userdal)
        {
            _userDal = userdal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }
        [SecuredOperation("Users.List")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(c => c.Email == email));
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(c=>c.Id == id));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetCurrentUser(IIdentity getidentity)
        {
                string userid = null;
                if (getidentity is ClaimsIdentity identity)
                {
                try { userid = identity.FindFirst(ClaimTypes.NameIdentifier).Value; } catch { userid = null; };
                }
                User currentUser = _userDal.Get(p => p.Id == Convert.ToInt32(userid));
            if(userid == null)
            {
                return new ErrorDataResult<User>("Giriş yapılmamış");
            }    
            return new SuccessDataResult<User>(currentUser);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
