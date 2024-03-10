using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Bridge
{
    // here we will specifiy the implementation details
    public class SamsungTv : ILEDTV
    {
        public void SwitchOn()
        {
            Console.WriteLine("Turning ON : Samsung TV");
        }
        public void SwitchOff()
        {
            Console.WriteLine("Turning OFF : Samsung TV");
        }
        public void SetChannel(int channelNumber)
        {
            Console.WriteLine("Setting channel Number " + channelNumber + " on Samsung TV");
        }
    }
}
