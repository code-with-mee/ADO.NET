using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
    public class App
    {
        private POSDBContext db = new POSDBContext();
        public void InsertData()
        {
            Category c = new Category();
            c.Name = "Drink";
            c.Created = DateTime.Now;
            c.Updated = DateTime.Now;

            db.Categories.Add(c);
            db.SaveChanges();
        }
    }
}
