﻿using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Facade
{
    public class Facade<TEntity> : IFacade<TEntity> where TEntity:Entity.Entity
    {
        IRepository<TEntity> repo = null;
        
        public Facade(DataContext context)
        {
            repo = new Repository<TEntity>(context);
        }

        public List<TEntity> GetAll()
        {
            return repo.GetAll();
        }

        public TEntity Get(int id)
        {
            return repo.Get(id);
        }

        public int Insert(TEntity entity)
        {
            return repo.Insert(entity);
        }

        public int Update(TEntity entity)
        {
            return repo.Update(entity);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
