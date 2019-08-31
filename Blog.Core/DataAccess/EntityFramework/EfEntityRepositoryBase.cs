using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.Core.Utilities;

namespace Blog.Core.DataAccess.EntityFramework
{
   public abstract class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
       where TEntity:class,new()
       where TContext:DbContext,new()
   {
       protected abstract TEntity AddEntity(TEntity entity, TContext context);

       protected abstract TEntity UpdateEntity(TEntity entity, TContext context);

       protected abstract List<TEntity> GetEntities(TContext context);

       protected abstract TEntity GetEntity(int id, TContext context);

        public List<TEntity> GetAll()
        {
            using (var context = new TContext())
            {
                return GetEntities(context);
            }
        }

        public TEntity Get(int id)
        {
            using (var context = new TContext())
            {
                return GetEntity(id,context);
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                TEntity addedEntity= AddEntity(entity,context);
                context.SaveChanges();
                return addedEntity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry<TEntity>(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                TEntity updatedEntity = UpdateEntity(entity, context);
                SimpleMapper.PropertyMap(entity, updatedEntity);
                context.SaveChanges();
                return updatedEntity;
            }
        }
    }
}
