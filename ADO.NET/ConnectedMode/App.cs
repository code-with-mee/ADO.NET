using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedMode
{
    public class App
    {
        private string connection = @"data source=BLOCKCHAINCAMBO\SQLDEV19;database=Demo;integrated security = true";
        public void ReadData()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Category");
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Id : " + reader.GetValue(0) + " | Name : " + reader.GetValue(1));
            }
            sqlConnection.Close();
        }

        public void InsertData()
        {
            String command = "INSERT INTO Category VALUES (@id,@name,@created,@updated)";
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Parameters.Add("@id", 20);
            sqlCommand.Parameters.Add("@name", "Energy Drink");
            sqlCommand.Parameters.Add("@created", DateTime.Now.ToString());
            sqlCommand.Parameters.Add("@updated", DateTime.Now.ToString());
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpdateData()
        {
            string command = "UPDATE Category SET Name = @name WHERE Id = @id";
            SqlConnection sqlConnection= new SqlConnection(connection);
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Parameters.Add("@name", "Drink (Beer)");
            sqlCommand.Parameters.Add("@id", 20);
            sqlCommand.Connection= sqlConnection;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DeleteData()
        {
            string command = "DELETE Category WHERE Id = @id";
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Parameters.Add("@id", 20);
            sqlCommand.Connection= sqlConnection;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void ReadFromView()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ViewGetProduct");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Name : " + reader.GetValue(1));
            }
            sqlConnection.Close();
        }

        public void ReadFromStoreProcedure()
        {
            SqlConnection sqlConnection= new SqlConnection(connection);
            SqlCommand sqlCommand = new SqlCommand("ProcGetProduct");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetValue(1));
            }
            sqlConnection.Close();
        }

        public void ReadFromStoreProcedureWithParameter() 
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand sqlCommand = new SqlCommand("ProcGetProductById");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@id", 2);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetValue(1));
            }
            sqlConnection.Close();
        }

        public void ReadFromStoreProcedureOutParameter()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand sqlCommand = new SqlCommand("ProcCountProductByCategoryId");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            //input parameter
            IDataParameter catId = sqlCommand.CreateParameter();
            catId.ParameterName = "@catId";
            catId.Value = 1;
            sqlCommand.Parameters.Add(catId);

            //output parameter
            IDataParameter count = sqlCommand.CreateParameter();
            count.ParameterName = "@count";
            count.DbType = DbType.Int32;
            count.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(count);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Count Product : " + count.Value);
            sqlConnection.Close();
        }

        public void ReadFromFunctionReturnScalar()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand sqlCommand = new SqlCommand("SELECT dbo.FuncCountCategory()");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            int count = (int)sqlCommand.ExecuteScalar();
            Console.WriteLine("count category : " + count);
            sqlConnection.Close();
        }

        public void ReadFromFunctionReturnScalarWithParameter()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand sqlCommand = new SqlCommand("SELECT dbo.FuncCountProductByCategoryId(@catId)");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add("@catId", 1);
            sqlConnection.Open();
            int count = (int)sqlCommand.ExecuteScalar();
            Console.WriteLine("count product : " + count);
            sqlConnection.Close();
        }

        public void ReadFromFunctionReturnTable()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM dbo.FuncGetProducts()");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine("Name : " + reader.GetString(1));
            }
        }
    }
}
