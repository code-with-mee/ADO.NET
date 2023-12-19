using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDesignerModel
{
    public class App
    {
        private POSDBContainer db = new POSDBContainer();
        public void InsertData()
        {
            Category c = new Category();
            c.Name = "Noodle";
            c.Created = DateTime.Now;
            c.Updated = DateTime.Now;

            db.Categories.Add(c);
            db.SaveChanges();
        }

        public void InsertProduct()
        {
            Product p = new Product();
            p.Name = "Fanta";
            p.Category = db.Categories.First();
            p.CostPrice = 3000;
            p.SellingPrice = 5000;
            p.Unit = "Unit";
            p.Created = DateTime.Now;
            p.Updated = DateTime.Now;
            db.Products.Add(p);
            db.SaveChanges();
        }

        public void ReadData()
        {
            foreach(Product p in db.Products)
                Console.WriteLine(p.Name);
        }
    }
}
