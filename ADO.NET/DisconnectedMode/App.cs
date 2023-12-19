using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisconnectedMode
{
    public class App
    {
        private string connection = @"data source=BLOCKCHAINCAMBO\SQLDEV19;database=Demo;integrated security = true";
        public void Read()
        {
            string command = "SELECT * FROM Category";
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command,sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet,"Category");
            for(int i = 0; i < dataSet.Tables.Count; i++)
            {
                DataTable table = dataSet.Tables[i];
                for(int j = 0; j < table.Rows.Count; j++)
                {
                    Console.WriteLine("Name : " + table.Rows[j].Field<string>("Name"));
                }
            }
        }

        public void Insert()
        {
            string command = "SELECT * FROM Category";
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Category");

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.SelectCommand = commandBuilder.GetInsertCommand();

            DataTable dt = dataSet.Tables["Category"];
            DataRow dr = dt.NewRow();
            dr["Id"] = 40;
            dr["Name"] = "Energy Drink 30";
            dr["created"] = DateTime.Now.ToString();
            dr["updated"] = DateTime.Now.ToString();
            dt.Rows.Add(dr);
            dataAdapter.Update(dataSet, "Category");
        }

        public void Update()
        {
            string command = "SELECT * FROM Category";
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Category");

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.SelectCommand = commandBuilder.GetUpdateCommand();

            DataTable dt = dataSet.Tables["Category"];
            foreach(DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["Id"]);
                if(id == 40)
                {
                    dr["Name"] = "Bakery123";
                }
            }

            dataAdapter.Update(dataSet, "Category");
        }

        public void Delete()
        {
            string command = "SELECT * FROM Category";
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Category");

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.SelectCommand = commandBuilder.GetDeleteCommand();

            DataTable dt = dataSet.Tables["Category"];
            for(int i = 0; i  < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int id = Convert.ToInt32(dr["Id"]);
                if (id == 40)
                {
                    //dt.Rows.Remove(dr);
                    dr.Delete();
                }
            }
            dataAdapter.Update(dataSet, "Category");
        }
    }
}
