using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUl
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager car = new CarManager(new InMemoryCarDal());
            foreach (var item in car.GetAll())
            {
                Console.WriteLine(item.DailyPrice);

            }
        }
    }
}
