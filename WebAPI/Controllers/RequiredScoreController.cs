using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequiredScoreController : ControllerBase
    {
        IRequiredScoreService _requiredScoreService;

        public RequiredScoreController(IRequiredScoreService requiredScoreService)
        {
            _requiredScoreService = requiredScoreService;
        }
        [HttpGet("getrequiredscore")]
        public IActionResult GetRequiredScore(int carId)
        {
            var result = _requiredScoreService.GetByCarId(carId);
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(RequiredScore requiredScore)
        {
            var result = _requiredScoreService.Add(requiredScore);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        public IActionResult Update(RequiredScore requiredScore)
        {
            var result = _requiredScoreService.Update(requiredScore);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
