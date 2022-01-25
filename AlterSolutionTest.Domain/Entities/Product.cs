using System;
using System.Collections.Generic;
using System.Text;

namespace AlterSolutionTest.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Dimensions { get; set; }
        public string Code { get; set; }
        public string Reference { get; set; }
        public int InventoryBalance { get; set; }
        public float Price { get; set; }
        public byte Active { get; set; }
        public int IdCategory { get; set; }
        public virtual Category Category { get; set; }
    }
}
