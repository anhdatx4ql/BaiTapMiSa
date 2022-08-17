using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfrastructure
{
    public interface IDapperRepository
    {
        /// <summary>
        /// Hàm lấy chuổi kết nối 
        /// Author: Phạm Văn Đạt
        /// DateTime: 20:50 10/08/2022
        /// </summary>
        /// <returns></returns>
        DbConnection GetDbconnection();
        //Task<List<T>> QueryAsync<T>(string sql, object parameters = null);

        /// <summary>
        /// Base get all table
        /// Author: Phạm Văn Đạt
        /// DateTime: 21:03 10/08/2022
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync<T>(string query, DynamicParameters sp_params = null);

        /// <summary>
        /// Base get tabke by cloumn
        /// Author: Phạm Văn Đạt
        /// DateTime: 21:03 10/08/2022
        /// </summary>
        /// <returns></returns>
        Task<T> GetByIdAsync<T>(string query, DynamicParameters sp_params = null);

        /// <summary>
        /// Base tạo mới dữ  liệu 
        /// Author: Phạm Văn Đạt
        /// DateTime: 21:07 10/08/2022
        /// </summary>
        /// <returns></returns>
        Task<int> CreateTAsync<T>(string sql, T entity);

        /// <summary>
        /// Base Update dữ liệu
        /// Author: Phạm Văn Đạt
        /// DateTime: 21:05 10/08/2022
        /// </summary>
        /// <returns></returns>
        Task<int> UpdateTAsync<T>(string sql, Object sp_params = null);

        /// <summary>
        /// Base Xóa dữ liệu
        /// Author: Phạm Văn Đạt
        /// DateTime: 21:08 10/08/2022
        /// </summary>
        /// <returns></returns>
        Task<int> DeleteTAsync<T>(string sql, T entity);


        /// <summary>
        /// Base Tìm kiếm
        /// Author: Phạm Văn Đạt
        /// DateTime: 21:03 10/08/2022
        /// </summary>
        /// <returns></returns>
        Task<T> FindCloumnTAsync<T>(string tableName, string cloumnName, string cloumnValue);


        /// DateTime: 21:03 10/08/2022
        /// TÌm kiếm bản ghi
        /// </summary>
        /// <returns></returns>
        Task<List<T>> FindTAsync<T>(string sql, Dictionary<string, object> sp_params = null);

        /// DateTime: 21:03 10/08/2022
        /// Xoá nhiều
        /// </summary>
        /// <returns></returns>
        Task<List<int>> DeleteMultipleAsync(string sql, DynamicParameters sp_params = null);

        /// DateTime: 21:03 10/08/2022
        /// Xoá nhiều
        /// </summary>
        /// <returns></returns>
        Task<int> CreateMultipleAsync(string sql, DynamicParameters sp_params = null);


    }
}

