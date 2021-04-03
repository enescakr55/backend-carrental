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
    public class ColorManager : IColorService
    {
        IColorDal _colordal;

        public ColorManager(IColorDal colordal)
        {
            _colordal = colordal;
        }
        [SecuredOperation("admin")]
        public IResult Add(Color color)
        {
            _colordal.Add(color);
            return new SuccessResult(Messages.Added);
        }
        [SecuredOperation("admin")]
        public IResult Delete(Color color)
        {
            _colordal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colordal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colordal.Get(c => c.ColorId == id));
        }
        [SecuredOperation("admin")]
        public IResult Update(Color color)
        {
            _colordal.Update(color);
            return new SuccessResult(Messages.Updated);
        }
    }
}
