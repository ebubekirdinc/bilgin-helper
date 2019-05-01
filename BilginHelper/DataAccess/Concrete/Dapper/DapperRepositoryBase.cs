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
        where TContext : IDapperContext, new()
    {
        private const string ConnectionString = "SERVER=.;DATABASE=DBName;Trusted_Connection=true;";
        private SqlConnection connection = new SqlConnection(ConnectionString);

        private const string SELECT_QUERY = "SELECT * FROM {0}";

        public TEntity Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Add(entity);
            }
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return connection.Query<TEntity>("").ToList();
            }
            else
            {
                //TODO : Lambda expression to sql query code
                return null;
            }
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
