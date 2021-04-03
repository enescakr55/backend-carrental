using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRequiredScoreService
    {
        IDataResult<RequiredScore> GetByCarId(int carId);
        IResult Update(RequiredScore requiredScore);
        IResult Add(RequiredScore requiredScore);
        IResult Delete(RequiredScore requiredScore);
    }
}
