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
        IWebHostEnvironment _webHostEnvironment;
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromForm] CarImage carImage ,[FromForm] IFormFile resim)
        {
            try
            {
                if(resim.Length > 0)
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "Resimler\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    FileInfo f = new FileInfo(path + resim.FileName);
                    string uzanti = f.Extension;
                    string randomName = Guid.NewGuid().ToString("n");
                    string filePath = path + randomName + uzanti;
                    using (FileStream fileStream = System.IO.File.Create(filePath))
                    {
                        resim.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    carImage.Date = DateTime.Now;
                    carImage.ImagePath = filePath;
                    return Ok(_carImageService.Add(carImage));
                }
            }
            catch
            {
                BadRequest("Bir hata oluştu");
            }
            return null;
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
            try
            {
                if (resim.Length > 0)
                {
                    CarImage carimg = _carImageService.GetById(carImage.Id).Data;
                    string imagepath = carimg.ImagePath;
                    System.IO.File.Delete(imagepath);
                    string path = AppDomain.CurrentDomain.BaseDirectory + "Resimler\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    FileInfo f = new FileInfo(path + resim.FileName);
                    string uzanti = f.Extension;
                    string randomName = Guid.NewGuid().ToString("n");
                    string filePath = path + randomName + uzanti;
                    using (FileStream fileStream = System.IO.File.Create(filePath))
                    {
                        resim.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    carImage.Date = DateTime.Now;
                    carImage.ImagePath = filePath;
                    return Ok(_carImageService.Update(carImage));
                }
            }
            catch
            {
                return BadRequest("Bir hata oluştu");
            }
            return null;
        }

    }
}
