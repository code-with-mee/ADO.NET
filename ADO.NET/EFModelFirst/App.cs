using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModelFirst
{
    public class App
    {
        private POSEntities db = new POSEntities();
        public void ReadData()
        {
            //foreach(Category c in db.Categories)
            //{
            //    Console.WriteLine("id : {0},name : {1}",
            //        c.Id,c.Name);
                
            //}

            foreach(Product p in db.Products)
            {
                Console.WriteLine("id : {0},name : {1}, category : {2}",
                                    p.Id,p.Name,p.Category.Name);
            }
        }

        public void InsertData()
        {
            Category category = new Category();
            category.Id = 70;
            category.Name = "Ford";
            category.Created = DateTime.Now;
            category.Updated = DateTime.Now;
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void InsertData2()
        {
            Product product = new Product();
            product.Id = 1021;
            product.Name = "Ford2025";
            //product.CategoryId = 1;
            product.Category = db.Categories.FirstOrDefault(); ;
            product.CostPrice = 50000;
            product.SellingPrice = 52000;
            product.Unit = "Unit";
            product.Created = DateTime.Now;
            product.Updated = DateTime.Now; 
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void UpdateData()
        {
            Product product = db.Products
                .Where(p => p.Id == 1021)
                .FirstOrDefault();
            if(product != null)
            {
                product.CategoryId = 6;
                product.Name = "Ford 2030";
                product.Updated = DateTime.Now;
                db.SaveChanges();
            }
        }

        public void DeleetData()
        {
            Product product = db.Products
                .Where(p => p.Id == 1021)
                .FirstOrDefault();
            if(product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}
