using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPattern.Command.Order;

namespace DesignPattern.Command
{
    public interface ICommandOrder
    {
        public void Execute(List<MenuItem> order, MenuItem newItem);
    }
}
