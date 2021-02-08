using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<CarDetailDto> GetCarDetails();
        Car GetById(int id);
        void Update(Car car);
        void Delete(Car car);
        void Add(Car car);
    }
}
