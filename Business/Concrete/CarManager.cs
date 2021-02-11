using Business.Abstract;
using Business.Constants;
using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));
        }

        public IResult Update(Car car)
        {
            if (car.CarName.Length < 2)
            {

                return new ErrorResult(Messages.CharLenght);

            }
            else if (car.DailyPrice < 0)
            {
                return new ErrorResult(Messages.PriceMin);
            }
                _carDal.Update(car);
                return new SuccessResult(Messages.Updated);
        }
        public IResult Add(Car car)
        {
            if(car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CharLenght);
            }
            else if(car.DailyPrice < 0)
            {
                return new ErrorResult(Messages.PriceMin);
            }
                _carDal.Add(car);
                return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
           return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
