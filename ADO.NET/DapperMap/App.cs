using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

namespace DapperMap
{
    public class App
    {
        private string connection = @"data source=BLOCKCHAINCAMBO\SQLDEV19;initial catalog=Demo;integrated security=true;";
        public void ReadData()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();

            string command = "SELECT * FROM Category";
            List<Category> categories = sqlConnection.Query<Category>(command).ToList();
            foreach (Category category in categories)
            {
                Console.WriteLine(category.Name);
            }
        }

        public void ReadDataFromStoreProcedure()
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            List<Category> categories = conn.Query<Category>("ProcGetCategories").ToList();
            foreach (Category category in categories)
            {
                Console.WriteLine(category.Name);
            }
        }

        public void ReadDataStoreWithParameter()
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            DynamicParameters dp = new DynamicParameters();
            dp.Add("@Id", 5);

            List<Category> categories = conn.Query<Category>("ProcGetCategoriesById",dp).ToList();
            foreach (Category category in categories)
            {
                Console.WriteLine(category.Name);
            }
        }

        public void InsertData()
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            DynamicParameters dp = new DynamicParameters();
            dp.Add("@Id", 15);
            dp.Add("@Name", "General Motor");

            conn.Execute("ProcAddCategory", dp,commandType: CommandType.StoredProcedure);
            conn.Close();
        }

        public void UpdateData()
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            DynamicParameters dp = new DynamicParameters();
            dp.Add("@Id", 15);
            dp.Add("@Name", "Ford");

            conn.Execute("ProcUpdateCategory", dp,commandType: CommandType.StoredProcedure);
            conn.Close();
        }

        public void DeleteData()
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            DynamicParameters dp = new DynamicParameters();
            dp.Add("@Id", 15);

            conn.Execute("ProcDeleteCategoryById", dp,commandType: CommandType.StoredProcedure);
            conn.Close();
        }
    }
}
