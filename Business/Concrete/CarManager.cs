using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _ICarDal;

        public CarManager(ICarDal ıCarDal)
        {
            _ICarDal = ıCarDal;
        }

        public void Add(Car car)
        {
            if (car.CarName.Length>2 && car.DailyPrice>0)
            {
                _ICarDal.Add(car);
                Console.WriteLine("car is Addded");
            }
            else
            {
                Console.WriteLine("car name cannot be smaller than 2 and the daily price of the car cannot be 0, please try again  ");
            }
        }

        public void Delete(Car car)
        {
            _ICarDal.Delete(car);
            Console.WriteLine("Car is Deleted");
        }

        public List<Car> GetAll()
        {
            return _ICarDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            return _ICarDal.GetCarDetail();
        }

        public List<Car> GetCarsByBrandId(int BranId)
        {
            return _ICarDal.GetAll(b => b.BrandId == BranId);
        }

        public List<Car> GetCarsByColorId(int CarId)
        {
            return _ICarDal.GetAll(b => b.CarId == CarId);
        }

        public void Update(Car car)
        {
            _ICarDal.Update(car);
            Console.WriteLine("Car is Updated");
        }
    }
}
