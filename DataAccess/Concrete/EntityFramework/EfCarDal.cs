using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentContext context = new CarRentContext())
            {
                var carDetail = from c in context.Cars
                                join r in context.Colors
                                on c.ColorId equals r.ColorId
                                join b in context.Brands
                                on c.BrandId equals b.BrandId
                                select new CarDetailDto
                                {
                                    CarName = c.CarName,
                                    ColorName = r.ColorName,
                                    BrandName = b.BrandName,
                                    DailyPrice = c.DailyPrice,
                                    Description = c.Description,
                                    Id = c.Id,
                                    ModelYear = c.ModelYear
                                };
                return carDetail.ToList();
                                
                                
            }
        }
    }
}
