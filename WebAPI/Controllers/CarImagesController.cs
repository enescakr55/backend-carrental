using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        string ImagePath = Environment.CurrentDirectory + "\\CarImagesFolder\\";
        [HttpPost("Add")]
        public IActionResult Add([FromForm] CarImage carImage ,[FromForm] IFormFile resim)
        {
            string filePath = UploadImage(resim);
            if(filePath == "0")
            {
                BadRequest("Bir hata oluştu");
            }
            carImage.Date = DateTime.Now;
            carImage.ImagePath = filePath;
            return Ok(_carImageService.Add(carImage));
        }
        [HttpPost("Delete")]
        public IActionResult Delete([FromForm] CarImage carImage)
        {
            CarImage carimg = _carImageService.GetById(carImage.Id).Data;
            string imagepath = carimg.ImagePath;
            System.IO.File.Delete(imagepath);
            _carImageService.Delete(carImage);
            return Ok();
        }
        [HttpPost("Update")]
        public IActionResult Update([FromForm] CarImage carImage,[FromForm] IFormFile resim)
        {
            string filePath = UploadImage(resim);
            if (filePath == "0")
            {
                BadRequest("Bir hata oluştu");
            }
            carImage.Date = DateTime.Now;
            carImage.ImagePath = filePath;
            return Ok(_carImageService.Update(carImage));
        }
        [HttpPost("getbycarid")]
        public IActionResult GetByCarId([FromForm] int carId)
        {
            return Ok(_carImageService.GetByCarId(carId));
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_carImageService.GetAll());
        }
        public string UploadImage(IFormFile resim)
        {
            try
            {
                if (resim.Length > 0)
                {
                    if (!Directory.Exists(ImagePath))
                    {
                        Directory.CreateDirectory(ImagePath);
                    }
                    FileInfo f = new FileInfo(ImagePath + resim.FileName);
                    string uzanti = f.Extension;
                    string randomName = Guid.NewGuid().ToString("n");
                    string filePath = ImagePath + randomName + uzanti;
                    using (FileStream fileStream = System.IO.File.Create(filePath))
                    {
                        resim.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    return filePath;

                }
            }
            catch
            {
                return "0";
            }
            return null;
        }

    }
}
