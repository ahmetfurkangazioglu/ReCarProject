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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCarProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetail()
        {
            using (ReCarProjectContext context = new ReCarProjectContext())
            {
                var result = from u in context.Users
                             join c in context.Customers on u.Id equals c.UserId
                             select new CustomerDetailDto
                             {
                                 UserId = u.Id,
                                 CustomerId=c.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName,
                                 Status = u.Status
                             };
                return result.ToList();
            }
        }
    }
}
