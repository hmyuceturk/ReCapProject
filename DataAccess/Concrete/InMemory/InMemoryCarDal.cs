﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { new Car {Id=1,BrandId=1,ColorId=1,DailyPrice=100,ModelYear=2009,Description="Egea" }
            ,new Car {Id=2,BrandId=2,ColorId=2,DailyPrice=200,ModelYear=2009,Description="Toyota" }
            ,new Car {Id=3,BrandId=3,ColorId=3,DailyPrice=300,ModelYear=2009,Description="Bmw" }
            ,new Car {Id=4,BrandId=4,ColorId=4,DailyPrice=400,ModelYear=2009,Description="Audi" }
            ,new Car {Id=5,BrandId=5,ColorId=5,DailyPrice=500,ModelYear=2009,Description="Mercedes" }};
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ColorId = car.BrandId;
        }
    }
}
