using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Update(Customer customer);
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<Customer> GetByUserIdOrCreate(int userid);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
    }
}
