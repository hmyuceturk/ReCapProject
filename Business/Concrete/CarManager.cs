using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;
        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        public void Add(Car car)
        {
            if(Validate(car))
            _iCarDal.Add(car);
        }

        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();            
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _iCarDal.GetAll(c=>c.BrandId==brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _iCarDal.GetAll(c => c.ColorId == colorId);
        }

        public bool Validate(Car car)
        {
            bool deger = true;
            if (car.Description.Length < 2) 
            { return false; }
            else if (car.DailyPrice <=0)
            { return false; }
            return true;
        }
    }
}
