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
        public List<CarDetailDto> GetCarDetail()
        {
            using (ReCarProjectContext context = new ReCarProjectContext())
            {
                var result = from c in context.cars
                             join b in context.brands on c.BrandId equals b.BrandId                            
                             join co in context.colors on c.ColorId equals co.ColorId                        
                             select new CarDetailDto 
                             { 
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice 
                             };

                return result.ToList();

            }
        }
    }
}
