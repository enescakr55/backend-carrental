using Core.Entities.Concrete;
using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ILoggedUserService
    {
        IResult Update(User loggedUser, UserInfoDTO user);
        IResult AddRentalForLoggedUser(User loggedUser, Rental rental, CreditCard creditCard);
        IDataResult<UserInfoDTO> GetProfileInfo(User loggedUser);
    }
}
