using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            app.InsertData();

            Console.WriteLine("Inserted!");
            Console.ReadLine();
        }
    }
}
