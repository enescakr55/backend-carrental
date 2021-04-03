using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCreditCardDal:EfEntityRepositoryBase<CreditCard,CarRentContext>, ICreditCardDal
    {

    }
}
