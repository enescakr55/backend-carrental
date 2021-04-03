using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggedUserController : ControllerBase
    {
        IUserService _userService;
        ILoggedUserService _loggedUserService;
        ICustomerService _customerService;
        IAuthService _authService;
        ICreditCardService _creditCardService;
        IFindexScoreService _findexScoreService;
        

        public LoggedUserController(IUserService userService,ILoggedUserService loggedUserService,ICustomerService customerService,IAuthService authService,ICreditCardService creditCardService, IFindexScoreService findexScoreService)
        {
            _userService = userService;
            _loggedUserService = loggedUserService;
            _customerService = customerService;
            _authService = authService;
            _creditCardService = creditCardService;
            _findexScoreService = findexScoreService;
        }

        [HttpGet("adsoyad")]
        public IActionResult AdSoyad()
        {
            var getLoggedUser = _userService.GetCurrentUser(HttpContext.User.Identity);
            if (getLoggedUser.Success)
            {
                return Ok(new SuccessDataResult<string>(getLoggedUser.Data.FirstName + " "+getLoggedUser.Data.LastName, "Token doğrulandı"));
            }
            else
            {
               return BadRequest(new ErrorDataResult<string>("Giriş yapılmamış"));
            }
        }
        [HttpGet("getprofileinfo")]
        public IActionResult GetProfileInfo()
        {
            var LoggedUser = _userService.GetCurrentUser(HttpContext.User.Identity).Data;
            var result = _loggedUserService.GetProfileInfo(LoggedUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("updateprofile")]
        public IActionResult UpdateProfile(UserInfoDTO user)
        {
            var LoggedUser = _userService.GetCurrentUser(HttpContext.User.Identity).Data;
            var result = _loggedUserService.Update(LoggedUser, user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("rent")]
        public IActionResult RentCar(CarRentAndPayDto rentalAndPay)
        {
            var LoggedUser = _userService.GetCurrentUser(HttpContext.User.Identity).Data;
            var getCustomer = _customerService.GetByUserIdOrCreate(LoggedUser.Id).Data;
            Rental rental = new Rental { CarId = rentalAndPay.CarId, CustomerId = getCustomer.Id ,RentDate=rentalAndPay.RentDate,ReturnDate=rentalAndPay.ReturnDate};
            CreditCard creditCard = new CreditCard { CardNo = rentalAndPay.CardNo, Cvv = rentalAndPay.Cvv, SonKullanim = rentalAndPay.SonKullanim };
            var result = _loggedUserService.AddRentalForLoggedUser(LoggedUser,rental,creditCard);
            if (result.Success)
            {
              _findexScoreService.SkorEkle(LoggedUser.Id);
              return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("renewtoken")]
        public IActionResult RenewToken()
        {
            var LoggedUser = _userService.GetCurrentUser(HttpContext.User.Identity).Data;
            var result = _authService.CreateAccessToken(LoggedUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getmycreditcards")]
        public IActionResult GetMyCreditCards()
        {
            var LoggedUser = _userService.GetCurrentUser(HttpContext.User.Identity).Data;
            var kartgetir = _creditCardService.GetCreditCardsByUser(LoggedUser);
            if (kartgetir.Success)
            {
                return Ok(kartgetir);
            }
            return BadRequest(kartgetir);
        }

        [HttpPost("savecreditcard")]
        public IActionResult SaveCreditCard(CreditCard creditCard)
        {
            var LoggedUser = _userService.GetCurrentUser(HttpContext.User.Identity).Data;
            var result = _creditCardService.Save(creditCard, LoggedUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getfindexscore")]
        public IActionResult GetFindexScore()
        {
            var LoggedUser = _userService.GetCurrentUser(HttpContext.User.Identity).Data;
            var result = _findexScoreService.GetByUserId(LoggedUser.Id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
