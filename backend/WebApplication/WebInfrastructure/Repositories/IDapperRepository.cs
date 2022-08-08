using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebInfrastructure.Entities;

namespace WebInfrastructure.Repositories
{
    public interface IDapperRepository
    {
        DbConnection GetDbconnection();
        //Task<List<T>> QueryAsync<T>(string sql, object parameters = null);

        Task<List<Users>> GetAsync();

        Task<List<T>> GetAllAsync<T>(string query);

        Task<T> GetByIdAsync<T>(string query, Object sp_params = null);
        Task<List<T>> GetTByNameAsync<T>(string query);

        Task<int> CreateTAsync<T>(string sql, T entity);

        Task<int> UpdateTAsync<T>(string sql, T entity);
        Task<int> DeleteTAsync<T>(string sql, T entity);

        Task<T> FindCloumnTAsync<T>(string tableName, string cloumnName, string cloumnValue);

        //int Execute(string sql, object parameters = null);
        //T QueryFirstOrDefault<T>(string sql, object parameters = null);
        //Task<List<Users>> GetAsync();

    }
}

