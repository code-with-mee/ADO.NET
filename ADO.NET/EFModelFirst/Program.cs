using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModelFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            //app.ReadData();
            //app.InsertData();
            //app.InsertData2();
            //app.UpdateData();
            app.DeleetData();
            Console.ReadLine(); 
        }
    }
}
