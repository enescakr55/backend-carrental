using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetByCarId(int id);
        IResult Update(CarImage carImage, IFormFile resim);
        IResult Delete(CarImage carImage);
        IResult Add(CarImage carImage, IFormFile resim);
    }
}
