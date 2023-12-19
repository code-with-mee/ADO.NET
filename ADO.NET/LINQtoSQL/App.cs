using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoSQL
{
    public class App
    {
        private POSDBDataContext db = new POSDBDataContext();
        public void Run()
        {
            foreach(Category category in db.Categories)
            {
                Console.WriteLine("Name : " + category.Name);
            }
        }

        public void ShowProduct()
        {
            var products = db.Products.Where(p => p.Id >= 500);
            foreach (var product in products)
            {
                Console.WriteLine(product.Id + " | " + product.Name);
            }
        }

        public void Insert()
        {
            Category category = new Category();
            category.Id = 50;
            category.Name = "Khmer Noodle";
            category.Created = DateTime.Now;
            category.Updated = DateTime.Now;

            db.Categories.InsertOnSubmit(category);
            db.SubmitChanges();
        }

        public void Update()
        {
            Category category = db.Categories
                    .Where(p => p.Id == 50).FirstOrDefault();
            if(category != null)
            {
                category.Name = "Indo Noodle";
            }
            db.SubmitChanges();
        }

        public void Delete()
        {
            Category category = db.Categories
                .Where(p =>p.Id == 50).FirstOrDefault();
            if(category != null)
            {
                db.Categories.DeleteOnSubmit(category);
                db.SubmitChanges();
            }
        }

        public void CallView()
        {
            var categories = db.ViewCategories;
            foreach(var category in categories)
            {
                Console.WriteLine(category.Name);
            }
        }

        public void CallStoreProcedure()
        {
            var products = db.GetProductByCategoryId(1);
            foreach(var product in products)
            {
                Console.WriteLine("Id : " + product.Id+  " name : " + product.Name);
            }
        }

        public void CallFunction()
        {
           int count =  db.GetCountProductByCategory(1).Value;
            Console.WriteLine("count : " + count);
        }

        public void Test()
        {
            db.NewTables.FirstOrDefault();
            Category category = db.Categories.FirstOrDefault();
        }
    }
}
