﻿using Core.DataAccess.EntityFramework;
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
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                            
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandId=c.BrandId,
                                 ColorId=c.ColorId,
                                Images=(from i in context.CarImages where i.CarId == c.CarId select i.ImagePath).ToList()


                             };

                return result.ToList();

            }
        }





        //düzenleme yapılcak

        public List<CarDetailDto> GetCarFilterDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCarProjectContext context = new ReCarProjectContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)

                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId

                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,

                                 Images=(from i in context.CarImages where i.CarId == c.CarId select i.ImagePath).ToList()

                             };


                return result.ToList();

            }
        }



    }
}
