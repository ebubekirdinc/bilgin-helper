using BilginHelper.DataAccess.Abstract;
using BilginHelper.DataAccess.Abstract.Dapper;
using BilginHelper.Entities.Abstract;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BilginHelper.DataAccess.Concrete.Dapper
{
    public class DapperRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DapperContext, new()
    {
        public virtual TEntity Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Add(entity);
            }
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().Count()
                    : context.Set<TEntity>().Count(filter);
            }
        }

        public virtual int Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Delete(entity);
            }
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Get(filter);
            }
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().GetAll()
                    : context.Set<TEntity>().GetAll(filter);
            }

        }

        public virtual TEntity Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Update(entity);
            }
        }
    }
}
