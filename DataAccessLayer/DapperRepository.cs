using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dapper;
using System.Configuration;
using System.Collections.ObjectModel;

namespace DataAccessLayer
{
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private string connectionString;
        public DapperRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString; //получение строки соед из app.config
        }
        public void Add(T item)
        {
            using (IDbConnection connectionDB = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Students (Name,Speciality,[Group]) VALUES(@Name, @Speciality,@Group); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? userId = connectionDB.Query<int>(sqlQuery, item).FirstOrDefault();
                item.Id = (int)userId;
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection connectionDB = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Students WHERE Id = @id";
                connectionDB.Execute(sqlQuery, new { id });
            }
        }
        public ObservableCollection<T> GetAll()
        {
            using (IDbConnection connectionDB = new SqlConnection(connectionString))
            {
                return new ObservableCollection<T>(connectionDB.Query<T>("SELECT * FROM Students").ToList());
            }
        }
        public T GetById(int Id)
        {
            using (IDbConnection connectionDB = new SqlConnection(connectionString))
            {
                return connectionDB.Query<T>("SELECT * FROM Users WHERE Id = @id", new { Id }).FirstOrDefault();
            }
        }
        public void Save() { }
    }
}
