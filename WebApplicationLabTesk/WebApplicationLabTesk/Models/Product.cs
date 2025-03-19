using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationLabTesk.Models
{
	public class Product
	{
		public int ID {  get; set; }
		public string ProductName { get; set; }
		public int ProductPrice { get; set; }

		public int ProductQuantity { get; set; }

		public string ProductCatagory { get; set; }

    }
}