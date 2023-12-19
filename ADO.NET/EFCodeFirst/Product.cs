using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal CostPrice {  get; set; }
        public decimal SellingPrice { get; set; }
        public string Unit {  get; set; }
        public DateTime Created {  get; set; }
        public DateTime Updated { get; set; }
    }
}
