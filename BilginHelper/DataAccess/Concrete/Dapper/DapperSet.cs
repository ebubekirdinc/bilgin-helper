using BilginHelper.Entities.Abstract;
using BilginHelper.Extensions.Concrete;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace BilginHelper.DataAccess.Concrete.Dapper
{
    public class DapperSet<TEntity> where TEntity : class, IEntity, new()
    {

        private SqlConnection connection;
        private string TableName;

        private string INSERT_QUERY = $"INSERT INTO {typeof(TEntity).Name} ({{0}}) VALUES ({{1}})";
        private string UPDATE_QUERY = $"UPDATE {typeof(TEntity).Name} SET {1}";
        private string DELETE_QUERY = $"DELETE FROM {typeof(TEntity).Name}";
        private string SELECT_QUERY = $"SELECT * FROM {typeof(TEntity).Name}";
        private string SELECT_FIRST_ENTITY_QUERY = $"SELECT TOP 1 * FROM {typeof(TEntity).Name}";
        private string COUNT_QUERY = $"SELECT COUNT(*) FROM {typeof(TEntity).Name}";

        public DapperSet(string sqlConnection)
        {
            connection = new SqlConnection(sqlConnection);
            TableName = typeof(TEntity).Name;
        }

        public TEntity Add(TEntity entity)
        {
            var properties = typeof(TEntity).GetProperties();
            string insertColums = "", parameterList = "", selectQuery = "";
            foreach (PropertyInfo property in properties)
            {
                if (Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) is KeyAttribute attribute)
                {
                    selectQuery = $"SELECT * FROM {TableName} WHERE {property.Name} = @@IDENTITY";
                }
                else if (property.Name == "Id")
                {
                    selectQuery = $"SELECT TOP 1 * FROM {TableName} WHERE Id = @@IDENTITY";
                }
                else if (property.Name == TableName + "Id")
                {
                    selectQuery = $"SELECT * FROM {TableName} WHERE {TableName + "Id"} = @@IDENTITY";
                }
                else
                {
                    insertColums += $"{property.Name},";
                    parameterList += $"@{property.Name},";
                }

            }
            insertColums = insertColums.TrimEnd(',');
            parameterList = parameterList.TrimEnd(',');
            return connection.QueryFirstOrDefault<TEntity>(string.Format(INSERT_QUERY, insertColums, parameterList) + $" {selectQuery}", entity);
        }
        public TEntity Update(TEntity entity)
        {
            var properties = typeof(TEntity).GetProperties();

            foreach (PropertyInfo property in properties)
            {

                if (Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) is KeyAttribute attribute)
                {
                    connection.Execute($"{string.Format(UPDATE_QUERY, "")} WHERE {property.Name} = @{property.Name}", entity);

                }

                if (property.Name == "Id")
                {
                    connection.Execute($"{string.Format(UPDATE_QUERY, "")} WHERE {property.Name} = @{property.Name}", entity);
                }
                else if (property.Name == typeof(TEntity).Name + "Id")
                {
                    connection.Execute($"{string.Format(UPDATE_QUERY, "")} WHERE {property.Name} = @{property.Name}", entity);
                }
            }

            return entity;
        }
        public int Delete(TEntity entity)
        {
            var properties = typeof(TEntity).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                var attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) as KeyAttribute;

                if (attribute != null)
                {
                    return connection.Execute($"{DELETE_QUERY} WHERE {property.Name} = @{property.Name}", entity);
                }

                if (property.Name == "Id")
                {
                    return connection.Execute($"{DELETE_QUERY} WHERE Id = @Id", entity);
                }
                else if (property.Name == TableName + "Id")
                {
                    return connection.Execute($"{DELETE_QUERY} WHERE {TableName}Id = @{TableName}Id", entity);
                }
            }

            return -1;

        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            LambdaBuilder lambdaBuilder = new LambdaBuilder();
            var query = lambdaBuilder.ToSql(filter);
            return connection.QueryFirstOrDefault<TEntity>($"{SELECT_FIRST_ENTITY_QUERY} WHERE {query.Sql}", query.Parameters);
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return connection.Query<TEntity>(SELECT_QUERY).ToList();
            }
            else
            {
                LambdaBuilder lambdaBuilder = new LambdaBuilder();
                var query = lambdaBuilder.ToSql(filter);
                return connection.Query<TEntity>($"{SELECT_QUERY} WHERE {query.Sql}", query.Parameters).ToList();
            }
        }
        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return connection.ExecuteScalar<int>(COUNT_QUERY);
            }
            else
            {
                LambdaBuilder lambdaBuilder = new LambdaBuilder();
                var query = lambdaBuilder.ToSql(filter);
                return connection.ExecuteScalar<int>($"{COUNT_QUERY} WHERE {query.Sql}", query.Parameters);
            }
        }
    }
}
