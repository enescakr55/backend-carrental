using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        
        IResult Pay(CreditCard creditCard);
        IResult Save(CreditCard creditCard, User user);
        IDataResult<List<CreditCard>> GetCreditCardsByUser(User user);
    }
}
