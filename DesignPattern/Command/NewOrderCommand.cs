using static DesignPattern.Command.Order;

namespace DesignPattern.Command
{
    public class NewOrderCommand : ICommandOrder
    {
        public void Execute(List<MenuItem> order, Order.MenuItem newItem)
        {
            order.Add(newItem);
        }
    }
}
