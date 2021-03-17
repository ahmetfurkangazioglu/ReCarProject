using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public  class EfCarImageDal : EfEntityRepositoryBase<CarImage, ReCarProjectContext>, ICarImageDal
    {

        public List<CarImagesDetailDto> GetCarImageDetail(Expression<Func<CarImage, bool>> filter = null)
        {
            using (ReCarProjectContext context = new ReCarProjectContext())
            {
                var result = from i in filter == null ? context.carImages : context.carImages.Where(filter)
                             join c in context.cars on i.CarId equals c.CarId
                             join b in context.brands on c.BrandId equals b.BrandId
                             join co in context.colors on c.ColorId equals co.ColorId
                             select new CarImagesDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ImagePath = i.ImagePath,
                                 Date = i.Date

                             };

                return result.ToList();
            }
        }
    }
}
