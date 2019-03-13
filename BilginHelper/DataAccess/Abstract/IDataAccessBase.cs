using BilginHelper.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilginHelper.DataAccess.Abstract
{
    public interface IDataAccessBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
    }
}
