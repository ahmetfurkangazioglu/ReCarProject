using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
           {
              new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=650,Description="Fast new model", ModelYear=2021},
              new Car{CarId=2, BrandId=2, ColorId=2, DailyPrice=50,Description="Fast and safe  model", ModelYear=2001},
              new Car{CarId=2, BrandId=2, ColorId=2, DailyPrice=80,Description="Fast and Friendly model", ModelYear=2008},
              new Car{CarId=2, BrandId=2, ColorId=2, DailyPrice=150,Description="Fast model", ModelYear=2012},

           };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car ToCarDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(ToCarDelete);              
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
           
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int BrandId)
        {
            return _car.Where(c => c.BrandId == BrandId).ToList();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetail(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car ToCarUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            ToCarUpdate.DailyPrice = car.DailyPrice;
            ToCarUpdate.Description = car.Description;
            ToCarUpdate.ModelYear = car.ModelYear;
        }
    }
}
