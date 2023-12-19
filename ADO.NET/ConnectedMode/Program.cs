using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedMode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            //app.ReadData();
            //app.InsertData();
            //app.UpdateData();
            //app.DeleteData();
            //app.ReadFromView();
            //app.ReadFromStoreProcedure();
            //app.ReadFromStoreProcedureWithParameter();
            //app.ReadFromStoreProcedureOutParameter();
            //app.ReadFromFunctionReturnScalar();
            //app.ReadFromFunctionReturnScalarWithParameter();
            app.ReadFromFunctionReturnTable();
            Console.ReadLine();
        }
    }
}
