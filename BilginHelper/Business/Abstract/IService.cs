using BilginHelper.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BilginHelper.Business.Abstract
{
    public interface IService<T> where T :class,IEntity,new()
    {
        T Add(T entity);
        T Update(T entity);
        int Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        int Count(Expression<Func<T, bool>> filter = null);
    }
}
