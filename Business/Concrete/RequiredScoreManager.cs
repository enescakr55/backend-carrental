using Business.Abstract;
using Business.BusinessAspects;
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
    public class RequiredScoreManager : IRequiredScoreService
    {
        IRequiredScoreDal _requiredScoreDal;

        public RequiredScoreManager(IRequiredScoreDal requiredScoreDal)
        {
            _requiredScoreDal = requiredScoreDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(RequiredScore requiredScore)
        {
            _requiredScoreDal.Add(requiredScore);
            return new SuccessResult(Messages.Added);
        }
        [SecuredOperation("admin")]
        public IResult Delete(RequiredScore requiredScore)
        {
            _requiredScoreDal.Delete(requiredScore);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<RequiredScore> GetByCarId(int carId)
        {
            var result = _requiredScoreDal.Get(p => p.CarId == carId);
            return new SuccessDataResult<RequiredScore>(result);
        }
        [SecuredOperation("admin")]
        public IResult Update(RequiredScore requiredScore)
        {
            _requiredScoreDal.Update(requiredScore);
            return new SuccessResult(Messages.Updated);
        }
    }
}
