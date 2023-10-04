using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Command
{
    public class RemoveOrderCommand : ICommandOrder
    {
        public void Execute(List<Order.MenuItem> order, Order.MenuItem newItem)
        {
           order.Remove(order.First(x => x.Item == newItem.Item));
        }
    }
}
