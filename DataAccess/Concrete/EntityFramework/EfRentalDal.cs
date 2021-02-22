using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
     public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCarProjectContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail(Expression<Func<Rental,bool>> filter=null)
        {
            using (ReCarProjectContext context = new ReCarProjectContext())
            {
                var result = from r in filter == null ? context.rentals : context.rentals.Where(filter)
                             join c in context.cars on r.CarId equals c.CarId
                             join cu in context.customers on r.CustomerId equals cu.CustomerId
                             join u in context.users on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 CarId = c.CarId,
                                 RentalId = r.Id,
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CarName = c.CarName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();




            }
        }
    }
}
