using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>{
                new Car { Id = 1, ColorId = 1, BrandId = 1, DailyPrice = 350, ModelYear = "2019", Description = "Tesla" },
                new Car { Id = 2, ColorId = 1, BrandId = 2, DailyPrice = 250, ModelYear = "2000", Description = "Volvo" },
                new Car { Id = 3, ColorId = 2, BrandId = 3, DailyPrice = 200, ModelYear = "2015", Description = "Fiat" },
                new Car { Id = 4, ColorId = 2, BrandId = 4, DailyPrice = 120, ModelYear = "2001", Description = "Tofaş" },

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int i)
        {
            Car car = _cars.SingleOrDefault(c => c.Id == i);
            return car;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
        }
    }
}
