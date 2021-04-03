using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;
        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IDataResult<List<CreditCard>> GetCreditCardsByUser(User user)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(card => card.UserId == user.Id));

        }

        [ValidationAspect(typeof(CreditCardValidator))]

        public IResult Pay(CreditCard creditCard)
        {
            return new SuccessResult("Ödeme gerçekleşti");
        }
        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Save(CreditCard creditCard, User user)
        {
            CreditCard creditCardtoAdd = creditCard;
            creditCardtoAdd.UserId = user.Id;
            _creditCardDal.Add(creditCardtoAdd);
            return new SuccessResult("Kart başarı ile eklendi.");
        }
    }
}
