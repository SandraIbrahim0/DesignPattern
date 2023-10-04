using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPattern.Command.Order;

namespace DesignPattern.Command
{
    public class DineChef
    {
        private DineChefRestaurant order;
        private ICommandOrder orderCommand;
        private MenuItem menuItem;
        public DineChef()
        {
            order = new DineChefRestaurant();
        }

        public void SetOrderCommand(int dineCommand)
        {
            orderCommand = new DineTableCommand().GetDineCommand(dineCommand);
        }
        public void SetMenuItem(MenuItem item)
        {
            menuItem = item;
        }
        public void ExecuteCommand()
        {
            order.ExecuteCommand(orderCommand, menuItem);
        }

        public void ShowCurrentOrder()
        {
            order.ShowOrders();
        }
        public class DineTableCommand
        {
            //Dine table method
            public ICommandOrder GetDineCommand(int dineCommand)
            {
                switch (dineCommand)
                {
                    case 1:
                        return new NewOrderCommand();
                    case 2:
                        return new ModifyOrderCommand();
                    case 3:
                        return new RemoveOrderCommand();
                    default:
                        return new NewOrderCommand();
                }
            }
        }
    }
}
