using Business.Abstract;
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

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(p => p.Id == id);
        }

        public void Update(Car car)
        {
            var islemOk = 1;
            if (car.CarName.Length < 2)
            {
                islemOk = 0;
                Console.WriteLine("Araç adı en az 2 karakter olmalıdır.");
                throw new Exception("Araç adı en az 2 karakter olmalıdır");
            }
            else if (car.DailyPrice < 0)
            {
                islemOk = 0;
                Console.WriteLine("Araç fiyatı 0 dan büyük olmalıdır");
                throw new Exception("Araç fiyatı 0 dan büyük olmalıdır");
            }
            if (islemOk == 1)
            {
                _carDal.Update(car);
            }
        }
        public void Add(Car car)
        {
            var islemOk = 1;
            if(car.CarName.Length < 2)
            {
                islemOk = 0;
                Console.WriteLine("Araç adı en az 2 karakter olmalıdır.");
            }else if(car.DailyPrice < 0)
            {
                islemOk = 0;
                Console.WriteLine("Araç fiyatı 0 dan büyük olmalıdır");
            }
            if(islemOk == 1)
            {
                _carDal.Add(car);
            } 
        }

        public List<CarDetailDto> GetCarDetails()
        {
           return _carDal.GetCarDetails();
        }
    }
}
