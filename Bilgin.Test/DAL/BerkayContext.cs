using BilginHelper.DataAccess.Concrete.Dapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bilgin.Test.DAL
{
    public class BerkayContext : DapperContext
    {
        public BerkayContext() : base("SERVER=.;DATABASE=TestDb;Trusted_Connection=true;")
        {

        }
        public DapperSet<Category> Categories { get; set; }
    }
}
