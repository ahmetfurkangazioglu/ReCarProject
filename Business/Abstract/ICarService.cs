using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
     public interface ICarService
    {
        List<Car> GetAll();
       List<Car> GetCarsByBrandId(int BranId);
        List<Car> GetCarsByColorId(int CarId);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<CarDetailDto> GetCarDetail();
    }
}
