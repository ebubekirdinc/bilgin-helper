using BilginHelper.Business.Abstract;
using BilginHelper.DataAccess.Abstract;
using BilginHelper.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BilginHelper.Business.Concrete
{
    public class ServiceBase<T> : IService<T> where T : class, IEntity, new()
    {
        private IDataAccessBase<T> _dataAccessBase;
        public ServiceBase(IDataAccessBase<T> dataAccessBase)
        {
            _dataAccessBase = dataAccessBase;
        }

        public T Add(T entity)
        {
            return _dataAccessBase.Add(entity);
        }

        public int Count(Expression<Func<T, bool>> filter = null)
        {
            return _dataAccessBase.Count(filter);
        }

        public int Delete(T entity)
        {
            return _dataAccessBase.Delete(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _dataAccessBase.Get(filter);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return _dataAccessBase.GetAll(filter);
        }

        public T Update(T entity)
        {
            return _dataAccessBase.Update(entity);
        }
    }
}
