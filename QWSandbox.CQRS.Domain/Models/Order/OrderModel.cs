using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWSandbox.CQRS.Domain.Base;

namespace QWSandbox.CQRS.Domain.Models.Order
{
    public class OrderModel : Auditable
    {
        public List<OrderItemModel> Items { get; set; } = new();
    }
}
