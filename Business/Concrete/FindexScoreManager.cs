using Business.Abstract;
using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindexScoreManager : IFindexScoreService
    {
        IFindexScoreDal _findexScoreDal;
        public FindexScoreManager(IFindexScoreDal findexScoreDal)
        {
            _findexScoreDal = findexScoreDal;
        }
        public IResult Add(FindexScore findexScore)
        {
            _findexScoreDal.Add(findexScore);
            return new SuccessResult("Findex Skoru başarı ile eklendi");
        }

        public IResult Delete(FindexScore findexScore)
        {
            _findexScoreDal.Delete(findexScore);
            return new SuccessResult("Findex Skoru başarı ile silindi");
        }

        public IDataResult<FindexScore> GetByUserId(int userid)
        {
            return new SuccessDataResult<FindexScore>(_findexScoreDal.Get(p => p.UserId == userid), "Kullanıcı findex puanı başarıyla getirildi");
        }

        public IResult SkorEkle(int userId,int eklenecek=100)
        {
            var kullaniciFindex = _findexScoreDal.Get(p => p.UserId == userId);
            if (kullaniciFindex == null)
            {
                _findexScoreDal.Add(new FindexScore { Score = eklenecek, UserId = userId });
            }
            else
            {
                kullaniciFindex.Score += eklenecek;
                _findexScoreDal.Update(kullaniciFindex);
            }
            return new SuccessResult("Skor başarı ile güncellendi");
        }

        public IResult Update(FindexScore findexScore)
        {
            _findexScoreDal.Update(findexScore);
            return new SuccessResult("Skor başarı ile güncellendi");
        }
    }
}
