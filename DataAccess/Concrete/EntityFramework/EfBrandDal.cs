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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                //var addedEntity = context.Entry(entity);
                //addedEntity.State = EntityState.Added;
                context.Brands.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                context.Brands.Remove(Get(b=>b.Id==entity.Id));
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                return context.Brands.FirstOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            //throw new NotImplementedException();
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                return filter == null
                    ? context.Brands.ToList()
                    : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                var updatedEntity = Get(b => b.Id == entity.Id);
                updatedEntity.Name = entity.Name;
                context.SaveChanges();
            }
            
        }
    }
}
