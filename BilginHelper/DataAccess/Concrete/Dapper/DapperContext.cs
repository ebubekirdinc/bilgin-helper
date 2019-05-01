using BilginHelper.DataAccess.Abstract.Dapper;
using BilginHelper.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilginHelper.DataAccess.Concrete.Dapper
{
    public class DapperContext : IDapperContext
    {

        public virtual DapperEntitySet<TEntity> Set<TEntity>() where TEntity : class, IEntity, new()
        {
            return new DapperEntitySet<TEntity>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
