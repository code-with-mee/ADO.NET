using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDesignerModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            //app.InsertData();
            //app.InsertProduct();
            app.ReadData();
            Console.ReadLine();
        }
    }
}
