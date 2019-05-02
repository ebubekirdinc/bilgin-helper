using BilginHelper.DataAccess.Concrete.Dapper;
using BilginHelper.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilginHelper.DataAccess.Abstract.Dapper
{
    public interface IDapperContext : IDisposable
    {
        DapperSet<TEntity> Set<TEntity>() where TEntity : class, IEntity, new();
    }
}
