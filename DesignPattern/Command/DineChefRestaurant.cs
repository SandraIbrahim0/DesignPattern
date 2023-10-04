using System;
using static DesignPattern.Command.Order;

namespace DesignPattern.Command
{
    public class DineChefRestaurant
    {
        public List<MenuItem> Orders { get; set; }

        public DineChefRestaurant()
        {
            Orders = new List<MenuItem>();
        }

        public void ExecuteCommand(ICommandOrder command, MenuItem item)
        {
            command.Execute(this.Orders, item);
        }

        public void ShowOrders()
        {
            foreach (var item in Orders)
            {
                item.DisplayOrder();
            }
        }
    }
}
