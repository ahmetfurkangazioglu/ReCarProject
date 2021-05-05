using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCarProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetail(Expression<Func<User, bool>> filter = null)
        {
            using (ReCarProjectContext context = new ReCarProjectContext())
            {
                var result = from u in filter == null ? context.Users : context.Users.Where(filter)
                             
                             select new CustomerDetailDto
                             {
                                 UserId = u.Id,
                                 CustomerId= (from c in context.Customers where c.UserId == u.Id select c.CustomerId).FirstOrDefault(),
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 PhoneNumber = u.PhoneNumber,
                                 CompanyName = (from c in context.Customers where c.UserId == u.Id select c.CompanyName).FirstOrDefault(),
                                 Status = u.Status
                                 
                             };
                return result.ToList();
            }
        }
    }
}
