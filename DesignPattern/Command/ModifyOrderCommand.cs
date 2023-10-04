using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Command
{
    public class ModifyOrderCommand : ICommandOrder
    {
        public void Execute(List<Order.MenuItem> order, Order.MenuItem newItem)
        {
            var item = order.Where(x => x.Item == newItem.Item).FirstOrDefault();
            if (item != null)
            {
                item.Quantity = newItem.Quantity;
                item.Tags = newItem.Tags;
                item.TableNumber = newItem.TableNumber;
            }
        }
    }
}
