using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWSandbox.CQRS.Domain.Base;

namespace QWSandbox.CQRS.Domain.Models.Order
{
    public class OrderItemModel : Auditable
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
