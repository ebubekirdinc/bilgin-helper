using BilginHelper.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilginHelper.DataAccess.Concrete.Dapper
{
    public class BerkayContext : DapperContext
    {
        public BerkayContext() : base("SERVER=.;DATABASE=TestDb;Trusted_Connection=true;")
        {

        }
        public DapperSet<Category> Categories { get; set; }
    }

    public class Category : IEntity
    {

    }
}
