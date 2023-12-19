using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
    public class POSDBContext : DbContext
    {
        public POSDBContext() : base("name=iPosConnection")
        {
            
        }

        public virtual DbSet<Category> Categories { get; set; } 
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
