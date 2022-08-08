using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebInfrastructure.Entities;

namespace WebInfrastructure.Repositories
{
    public class DapperRepository: IDapperRepository
    {

        public DapperRepository()
        {

        }

        public DbConnection GetDbconnection()
        {
            return new MySqlConnection("server=127.0.0.1;user id=root;password=Anhdat=123;port=3306;database=projectmisa;");
            //return new MySqlConnection(@"Server=127.0.0.1;User Id=root;Password='Anhdat=123';Database=projectmisa");
        }

        // Author: Phạm Văn Đạt
        // Láy tất cả các cột trong bảng
        // Created: 11:12 07/08/2022
        public async Task<List<T>> GetAllAsync<T>(string query)
        {
            using (IDbConnection db = GetDbconnection())
            {
                db.Open();
                var results = await db.QueryAsync<T>(query);
                db.Close();
                return results.ToList();
            }
        }

        // Author: Phạm Văn Đạt
        // Láy cột chứa id trong bảng - ch
        // Created: 11:12 07/08/2022
        public async Task<T> GetByIdAsync<T>(string query, Object sp_params = null)
        {
            using (IDbConnection db = GetDbconnection())
            {
                db.Open();
                var result = await db.QuerySingleOrDefaultAsync<T>(query, sp_params);
                db.Close();
                return result;
            }
        }

        /// Author: Phạm Văn Đạt
        // Láy tất cả các cột trong bảng
        // Created: 11:12 07/08/2022
        public async Task<List<T>> GetTByNameAsync<T>(string query)
        {
            using (IDbConnection db = GetDbconnection())
            {
                db.Open();
                var result = await db.QueryAsync<T>(query);
                db.Close();
                return result.ToList();
            }
        }



        /// Author: Phạm Văn Đạt
        // Tạo cột mới
        // Created: 20:12 07/08/2022
        //Execute: dùng để thao tác thay đổi dữ liệu  INSERT, UPDATE, and DELETE operations.
        public async Task<int> CreateTAsync<T>(string sql, T entity)
        {
            using (IDbConnection db = GetDbconnection())
            {
                db.Open();
                var result = await db.ExecuteAsync(sql, entity);
                db.Close();
                return result;
            }
        }


        /// Author: Phạm Văn Đạt
        // Tạo cột mới
        // Created: 20:12 07/08/2022
        //Execute: dùng để thao tác thay đổi dữ liệu  INSERT, UPDATE, and DELETE operations.
        public async Task<int> UpdateTAsync<T>(string sql, T entity)
        {
            using (IDbConnection db = GetDbconnection())
            {
                db.Open();
                var result = await db.ExecuteAsync(sql, entity);
                db.Close();
                return result;
            }
        }

        public async Task<int> DeleteTAsync<T>(string sql, T entity)
        {
            using (IDbConnection db = GetDbconnection())
            {
                db.Open();
                var result = await db.ExecuteAsync(sql, entity);
                db.Close();
                return result;
            }
        }

        public async Task<T> FindCloumnTAsync<T>(string tableName,string cloumnName, string cloumnValue)
        {
            string sql = "Select * from " + tableName + " WHERE " + cloumnName + " = '" + cloumnValue + "';";
            using (IDbConnection db = GetDbconnection())
            {
                db.Open();
                var result = await db.QuerySingleOrDefaultAsync<T>(sql);
                db.Close();
                return result;
            }
        }



        //public async Task<List<T>> QueryAsync<T>(string sql, object parameters = null)
        //{
        //    using(IDbConnection db = GetDbconnection())
        //    {
        //        db.Open();
        //        IEnumerable<T> results = await db.QueryAsync<T>(sql, parameters);
        //        db.Close();
        //        return results.ToList();
        //    }

        //}


        public async Task<List<Users>> GetAsync()
        {

            try
            {
                var connectionString = new MySqlConnection(@"Server=127.0.0.1;User Id=root;Password='Anhdat=123';Database=projectmisa");


                var sql = "SELECT * FROM users";
                using (var connection = connectionString)
                {
                    connection.Open();
                    var result = await connection.QueryAsync<Users>(sql);
                    connection.Close();
                    return result.ToList();
                }
            }
            catch
            {
                return null;
            }


        }

    }
}
