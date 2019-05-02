using BilginHelper.DataAccess.Abstract.Dapper;
using BilginHelper.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilginHelper.DataAccess.Concrete.Dapper
{
    public class DapperContext : IDapperContext
    {
        private string sqlConn;
        public DapperContext(string sqlConnection)
        {
            sqlConn = sqlConnection;
        }
        public virtual DapperSet<TEntity> Set<TEntity>() where TEntity : class, IEntity, new() => new DapperSet<TEntity>(sqlConn);

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
