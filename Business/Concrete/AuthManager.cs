using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        ITokenHelper _tokenHelper;
        ICustomerService _customerService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper,ICustomerService customerService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _customerService = customerService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult IsTokenActive()
        {
            return new SuccessResult();
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            if (UserExists(userForRegisterDto.Email).Success == false)
            {
                return new ErrorDataResult<User>(Messages.UserExists);
            }
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Status = true,
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            var emailSorgu = _userService.GetByEmail(email);
            if (emailSorgu.Data != null)
            {
                return new ErrorResult(Messages.UserExists);
            }
            return new SuccessResult();
        }
    }
}
