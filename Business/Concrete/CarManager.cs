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
    }
}
