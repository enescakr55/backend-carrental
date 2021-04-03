using Core.Entities.Concrete;
using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Login(UserForLoginDto userForLoginDto); 
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto,string password);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult IsTokenActive();
    }
}
