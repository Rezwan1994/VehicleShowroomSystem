using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity:Entity.Entity
    {
        DataContext context = null;
        public Repository(DataContext dataContext)
        {
            context =dataContext;
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }
        
        public int Insert(TEntity entity)
        {
            int res = 0;
            try
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            return res;
        }
        public int Update(TEntity entity)
        {
            try
            {
                context.Entry<TEntity>(entity).State = EntityState.Modified;
                //context.Set<TEntity>().AddOrUpdate(entity);

                return context.SaveChanges();
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public int Delete(int id)
        {
            TEntity entity = Get(id);
            context.Set<TEntity>().Remove(entity);
            return context.SaveChanges();
        }
    }
}
