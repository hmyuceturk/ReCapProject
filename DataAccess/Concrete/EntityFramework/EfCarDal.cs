using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                var addedEntry = context.Entry(entity);
                addedEntry.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                var deletedEntry = context.Entry(entity);
                deletedEntry.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                return context.Cars.SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                return filter == null
                    ? context.Cars.ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                var updatedEntry = context.Entry(entity);                
                updatedEntry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
