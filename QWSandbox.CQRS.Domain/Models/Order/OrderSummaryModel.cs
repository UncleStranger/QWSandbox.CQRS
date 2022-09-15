using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWSandbox.CQRS.Domain.Models.Order
{
	public class OrderSummaryModel
	{
		public DateTime Date { get; set; }
		public int ItemsCount { get; set; }
		public decimal Sum { get; set; }
	}
}
