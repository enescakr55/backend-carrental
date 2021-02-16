using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (CarRentContext context = new CarRentContext())
            {
                var customerDetail = from c in context.Customers
                            join u in context.Users
                            on c.UserId equals u.Id
                            select new CustomerDetailDto
                            {
                                CompanyName = c.CompanyName,
                                CustomerId = c.Id,
                                Email = u.Email,
                                FirstName = u.FirstName,
                                LastName = u.LastName
                            };
                return customerDetail.ToList();
                            

                            
            }
        }
    }
}
