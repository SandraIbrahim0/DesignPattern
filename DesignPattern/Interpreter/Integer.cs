using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Interpreter
{
    public class IntegerElement : IElement
    {
        public int Value { get; }
        public IntegerElement(int value)
        {
            Value = value;
        }

    }
}
