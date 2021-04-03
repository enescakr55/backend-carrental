using Core.Entities.Concrete;
using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFindexScoreService
    {
        IDataResult<FindexScore> GetByUserId(int userid);
        IResult Update(FindexScore findexScore);
        IResult Add(FindexScore findexScore);
        IResult Delete(FindexScore findexScore);
        IResult SkorEkle(int userId,int eklenecek=100);




    }
}
