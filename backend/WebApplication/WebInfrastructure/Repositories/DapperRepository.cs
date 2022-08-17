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

namespace WebInfrastructure
{
    public class DapperRepository : IDapperRepository
    {

        public DapperRepository()
        {

        }

        public DbConnection GetDbconnection()
        {
            return new MySqlConnection(@"Server=localhost;Uid=root;Password=Anhdat=123;Database=baitaplonmisa");
            //return new MySqlConnection(@"Server=127.0.0.1;User Id=root;Password='Anhdat=123';Database=projectmisa");
        }

        // Author: Phạm Văn Đạt
        // Láy tất cả các cột trong bảng
        // Created: 11:12 07/08/2022
        public async Task<List<T>> GetAllAsync<T>(string query, DynamicParameters sp_params = null)
        {
            using (IDbConnection db = GetDbconnection())
            {
                db.Open();
                var results = await db.QueryAsync<T>(query, sp_params);
                db.Close();
                return results.ToList();
            }
        }

        // Author: Phạm Văn Đạt
        // Láy cột trong bảng - ch
        // Created: 11:12 07/08/2022
        public async Task<T> GetByIdAsync<T>(string query, DynamicParameters sp_params = null)
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
        public async Task<int> UpdateTAsync<T>(string sql, Object sp_params = null)
        {
            using (IDbConnection db = GetDbconnection())
            {
                db.Open();
                var Result = await db.ExecuteAsync(sql,sp_params);
                db.Close();
                return Result;
            }
        }


        /// <summary>
        /// Xóa cột
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// </summary>
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


        /// <summary>
        /// Tìm kiếm côt
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// </summary>
        public async Task<T> FindCloumnTAsync<T>(string tableName, string cloumnName, string cloumnValue)
        {
            string sql = "Select "+ cloumnName + " from " + tableName + " WHERE " + cloumnName + " = '" + cloumnValue + "';";
            using (IDbConnection db = GetDbconnection())
            {
                db.Open();
                var result = await db.QuerySingleOrDefaultAsync<T>(sql);
                db.Close();
                return result;
            }
        }


        /// <summary>
        /// Tìm kiếm bản ghi
        /// Author: Phạm văn Đạt
        /// 20;34 10/08/2022
        /// </summary>
        public async Task<List<T>> FindTAsync<T>(string sql, Dictionary<string, object> sp_params = null)
        {
            using (IDbConnection db = GetDbconnection())
            {
                db.Open();
                var results = await db.QueryAsync<T>(sql, sp_params);
                db.Close();
                return results.ToList();
            }
        }

        /// DateTime: 21:03 10/08/2022
        /// Xoá nhiều
        /// </summary>
        /// <returns></returns>
        public async Task<List<int>> DeleteMultipleAsync(string sql, DynamicParameters sp_params = null)
        {
           
            using (IDbConnection db = GetDbconnection())
            {
                db.Open();
                var result = await db.QueryMultipleAsync(sql, sp_params);
               
                db.Close();
                return result.Read<int>().ToList();
            }
        }



        /// DateTime: 21:03 10/08/2022
        /// truy vấn nhiều
        /// </summary>
        /// <returns></returns>
        public async Task<int> CreateMultipleAsync(string sql, DynamicParameters sp_params = null)
        {
            using (IDbConnection db = GetDbconnection())
            {
                db.Open();
                var result = await db.ExecuteAsync(sql, sp_params);
                db.Close();
                return result;
            }
        }


    }
}
