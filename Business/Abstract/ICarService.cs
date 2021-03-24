﻿using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
     public interface ICarService
    {
        IDataResult< List<Car>> GetAll();
        IDataResult< List<CarDetailDto>> GetCarsByBrandId(int Id);  
         IDataResult<List<CarDetailDto>> GetCarsByColorId(int Id);
        IDataResult<List<CarDetailDto>> GetCarsByCarId(int Id);
        IDataResult<List<CarDetailDto>> GetCarsByFilter(int brandId,int colorId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult< List<CarDetailDto>> GetCarDetail();
        IResult AddTransactionalTest(Car car);       
    }
}
