using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car {Description="a",DailyPrice=0 });
            Console.WriteLine("---------------------------");

            foreach (var c in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(c.Description);
            }

            foreach (var c in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(c.Description);
            }

            Console.WriteLine("---------------------------");

            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine( colorManager.GetColorById(1).Name);
            foreach (var c in colorManager.GetAll())
            {
                Console.WriteLine(c.Name);
            }
            Console.WriteLine("---------------------------");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name="Porsche"});

            Console.WriteLine("---------------------------");

            //CarManager carManager = new CarManager(new EfCarDal());
            foreach(var c in carManager.GetAll())
            { 
            Console.WriteLine(c.Description);
            }
        }
    }
}
