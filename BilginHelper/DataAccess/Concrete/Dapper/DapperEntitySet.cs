using BilginHelper.Entities.Abstract;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BilginHelper.DataAccess.Concrete.Dapper
{
    public class DapperEntitySet<TEntity> where TEntity : class, IEntity, new()
    {
        private const string ConnectionString = "SERVER=.;DATABASE=TestDb;Trusted_Connection=true;";
        private SqlConnection connection = new SqlConnection(ConnectionString);

        private string entityTableName = typeof(TEntity).Name;
        private List<string> propertyList;
        private List<string> parameterList;


        public DapperEntitySet()
        {
            propertyList = new List<string>();
            parameterList = new List<string>();

            foreach (var property in typeof(TEntity).GetProperties())
            {
                propertyList.Add(property.Name);
                parameterList.Add("@" + property.Name);
            }
        }

        private const string INSERT_QUERY = "INSERT INTO {0} ({1}) VALUES ({2}) " +
            "SELECT * FROM {0} WHERE [{0}].Id = @@IDENTITY";
        public TEntity Add(TEntity entity)
        {
            return connection.QueryFirstOrDefault<TEntity>
                (string.Format(INSERT_QUERY, entityTableName, string.Join(",", propertyList).Replace("Id,",""), string.Join(",", parameterList).Replace("@Id,", "")), entity);
        }
    }
}
