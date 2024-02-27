﻿using Dapper;
using MyWebFormApp.BO;
using MyWebFormApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace MyWebFormApp.DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        private string GetConnectionString()
        {
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                //var strSql = @"select * from Categories order by CategoryName";
                var strSql = @"usp_GetCategories";

                var results = conn.Query<Category>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public Category GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Categories where CategoryID = @CategoryID";
                var param = new { CategoryID = id };
                var result = conn.QuerySingleOrDefault<Category>(strSql, param);
                return result;
            }
        }

        public IEnumerable<Category> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
