using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCarProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCarProjectContext context = new ReCarProjectContext())
            {
                var result = from c in filter == null ? context.cars : context.cars.Where(filter)
                             join b in context.brands on c.BrandId equals b.BrandId
                             join co in context.colors on c.ColorId equals co.ColorId
                             join i in context.carImages on c.CarId equals i.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 Date = i.Date,
                                 ImagePath = (from a in context.carImages where a.CarId == c.CarId select a.ImagePath).FirstOrDefault()


                             };

                return result.ToList();

            }
        }
    }
}
