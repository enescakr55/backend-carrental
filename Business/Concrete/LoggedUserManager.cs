using Business.Abstract;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Results.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results.DataResults;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Business.Concrete
{
    public class LoggedUserManager : ILoggedUserService
    {
        IUserService _userService;
        ICustomerService _customerService;
        IRentalService _rentalService;
        ICreditCardService _creditCardService;
        IFindexScoreService _findexScoreService;
        IRequiredScoreService _requiredScoreService;

        public LoggedUserManager(IUserService userService, IRentalService rentalService,ICustomerService customerService,ICreditCardService creditCardService, IFindexScoreService findexScoreService, IRequiredScoreService requiredScoreService)
        {
            _customerService = customerService;
            _userService = userService;
            _rentalService = rentalService;
            _creditCardService = creditCardService;
            _findexScoreService = findexScoreService;
            _requiredScoreService = requiredScoreService;
        }
        public IResult Update(User loggedUser,UserInfoDTO user)
        {
            loggedUser.FirstName = user.FirstName;
            loggedUser.LastName = user.LastName;
            loggedUser.Email = user.Email;
            var updateResult = _userService.Update(loggedUser);
            if (updateResult.Success)
            {
                return new SuccessResult("Profiliniz Güncellendi");
            }
            return new ErrorResult();
        }
        public IDataResult<UserInfoDTO> GetProfileInfo(User loggedUser)
        {
            var userinfo = _userService.GetById(loggedUser.Id);
            var userInfoDTO = new UserInfoDTO { Email = userinfo.Data.Email, FirstName = userinfo.Data.FirstName, LastName = userinfo.Data.LastName };
            return new SuccessDataResult<UserInfoDTO>(userInfoDTO);
        }
        [TransactionScopeAspect]
        public IResult AddRentalForLoggedUser(User loggedUser, Rental rental,CreditCard creditCard)
        {
            var customer = _customerService.GetByUserIdOrCreate(loggedUser.Id);
            var IslemSonucu = BusinessRules.Run(customer, FindexScoreControl(loggedUser,rental.CarId));
            if(IslemSonucu == null)
            {
                var kirala = _rentalService.Add(rental);
                _creditCardService.Pay(creditCard);
                return kirala;
            }
            return IslemSonucu;

            
        }
        private IResult FindexScoreControl(User user, int carId)
        {
            var getRequiredScore = _requiredScoreService.GetByCarId(carId);
            var requiredScore = getRequiredScore.Data == null ? 0 : getRequiredScore.Data.MinimumScore;
            var getUserScore = _findexScoreService.GetByUserId(user.Id);
            var userScore = getUserScore.Data == null ? 0 : getUserScore.Data.Score;
            if (userScore >= requiredScore)
                return new SuccessResult("Puan yeterli araç kiralanabilir");
            return new ErrorResult("Bu aracı kiralamak için puanınız yetersiz");
        }

    }
}
