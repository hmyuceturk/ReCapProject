using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                //var addedEntity = context.Entry(entity);
                //addedEntity.State = EntityState.Added;
                context.Colors.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                context.Colors.Remove(Get(b => b.Id == entity.Id));
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                return context.Colors.FirstOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            //throw new NotImplementedException();
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                return filter == null
                    ? context.Colors.ToList()
                    : context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
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
