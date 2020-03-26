using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventsDemo.Demo;

namespace EventsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo d = new Demo();
            d.Changed += D_Changed1;
            
            d.Exevute();
            
            Console.Read();

        }

        private static void D_Changed1(object sender, EventArgs args)
        {
            Console.WriteLine(args.ToString()); ;
        }

        private static void D_Changed(string message)
        {
            Console.WriteLine(message);
        }
    }
}
