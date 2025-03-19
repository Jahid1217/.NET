using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationLabTesk.Models;

namespace WebApplicationLabTesk.ViewModels
{
	public class CustomerView
	{
        public List< Costomer> cstmr { get; set; }
        public Product pr { get; set; }
    }
}