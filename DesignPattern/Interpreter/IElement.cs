using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Interpreter
{
    public interface IElement
    {
        int Value { get; }
    }
    public class Integer : IElement
    {
        public int Value { get; }
        public Integer(int value)
        {
            Value = value;
        }
    }
}
