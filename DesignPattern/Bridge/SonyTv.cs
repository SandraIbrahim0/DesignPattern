using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Bridge
{
    public class SonyTv : ILEDTV
    {
        // here we will specifiy the implementation details
        public void SwitchOn()
        {
            Console.WriteLine("Turning ON : Sony TV");
        }
        public void SwitchOff()
        {
            Console.WriteLine("Turning OFF : Sony TV");
        }
        public void SetChannel(int channelNumber)
        {
            Console.WriteLine("Setting channel Number " + channelNumber + " on Sony TV");
        }
    }
}

