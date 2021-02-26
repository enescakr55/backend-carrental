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
        [HttpPost("Add")]
        public IActionResult Add([FromForm] CarImage carImage ,[FromForm] IFormFile resim)
        {
            return Ok(_carImageService.Add(carImage,resim));
        }
        [HttpPost("Delete")]
        public IActionResult Delete([FromForm] CarImage carImage)
        {
            _carImageService.Delete(carImage);
            return Ok();
        }
        [HttpPost("Update")]
        public IActionResult Update([FromForm] CarImage carImage,[FromForm] IFormFile resim)
        {
            return Ok(_carImageService.Update(carImage,resim));
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


    }
}
