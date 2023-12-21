using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            //app.ReadData();
            //app.ReadDataFromStoreProcedure();
            //app.ReadDataStoreWithParameter();

            //app.InsertData();
            //app.UpdateData();
            app.DeleteData();

            Console.ReadLine();
        }
    }
}
