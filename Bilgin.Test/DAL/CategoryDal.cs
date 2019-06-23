using BilginHelper.DataAccess.Concrete.Dapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bilgin.Test.DAL
{
    public class CategoryDal /*: DapperRepositoryBase<Entities.Category, BerkayContext>*/
    {
        public Category Add(Category cat)
        {
            BerkayContext context = new BerkayContext();
            return context.Set<Category>().Add(cat);
        }
    }
}
