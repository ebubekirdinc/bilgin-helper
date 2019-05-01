using BilginHelper.DataAccess.Concrete.Dapper;
using BilginHelper.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilginHelper.Tests
{
    public class CategoryDal:DapperRepositoryBase<Category,DapperContext>
    {
        
    }
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
