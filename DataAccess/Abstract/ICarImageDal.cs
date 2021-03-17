﻿using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICarImageDal : IEntityRepository<CarImage>
    {
         List<CarImagesDetailDto> GetCarImageDetail(Expression<Func<CarImage, bool>> filter = null);
    }
}
