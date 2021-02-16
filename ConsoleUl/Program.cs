using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUl
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car { BrandId = 1, CarName = "po", ColorId = 2, DailyPrice = 124, Description = "Fast and perfect", ModelYear = 2021 };
            CarManager car = new CarManager(new EfCarDal());
            car.Add(car1);
                       
            foreach (var cars in car.GetCarsByBrandId(2))
            {
                Console.WriteLine(cars.DailyPrice);
           }
        }
    }
}
