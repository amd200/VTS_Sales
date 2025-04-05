using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedOn { get; set; }
        public int CategoryId { get; set; } 
        public Category Category { get; set; } 

        public Product()
        {
            AddedOn = DateTime.Now;
        }
    }
}