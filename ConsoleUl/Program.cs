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
            Car car1 = new Car { CarId=2002, BrandId = 1, CarName = "poe", ColorId = 2, DailyPrice = 124, Description = "Fast and perfect", ModelYear = 2021 };
            Car car2 = new Car {  BrandId = 2, CarName = "Example", ColorId = 3, DailyPrice = 152, Description = "Fast and Safe", ModelYear = 2019 };
            CarManager car = new CarManager(new EfCarDal());
            //car.Update(car1);
            //  car.Delete(car1)
         //   car.Add(car2);
                       
            foreach (var cars in car.GetCarDetail())
            {
                Console.WriteLine(cars.CarName+" -- "+cars.BrandName+" -- "+ cars.ColorName+" -- "+cars.DailyPrice);
            }
        }
    }
}
