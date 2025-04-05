using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.ViewModels
{
	public class ProductFromViewModel
	{
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public DateTime AddedOn { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}