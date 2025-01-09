using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univercity_objects.Domain;

namespace Univercity_objects.Infrastructure.Repository
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        protected BaseContext context;
        protected DbSet<TEntity> dbSet;
        public GenericRepository(BaseContext context) 
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual TEntity Get(Guid guid)
        {
            return dbSet.Find(guid);
        }

        public virtual void Create(TEntity item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }

        public virtual void Update(TEntity item)
        {
            dbSet.Update(item);
            context.SaveChanges();
        }

        public virtual void Delete(Guid guid)
        {
            TEntity entity = dbSet.Find(guid);
            if (entity != null)
            {
                dbSet.Remove(entity);
                context.SaveChanges();
            }
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }
    }
}
