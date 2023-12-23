using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Models
{
	internal class Order
	{
		public int Id { get; set; }
		public int OrderDate { get; set; }
		public string Status { get; set; }
		public double TotalAmount { get; set; }


	}
}
