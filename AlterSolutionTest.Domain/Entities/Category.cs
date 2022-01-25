using System;
using System.Collections.Generic;
using System.Text;

namespace AlterSolutionTest.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte Active { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
