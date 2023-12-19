using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            //app.Run();
            //app.ShowProduct();
            //app.Insert();
            //app.Update();
            //app.Delete();

            //app.CallView();
            //app.CallStoreProcedure();
            app.CallFunction();

            Console.ReadLine();
        }
    }
}
