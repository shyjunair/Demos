using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDemo;

namespace EventsDemo
{
   public class Demo
    {
        public delegate void DemoDelegate(string message);
        public delegate string DemoDelegate3(int a, string y);
        public delegate int DemoDelegate2();
        public delegate void ValueChanged(object sender, EventArgs args);

        public event ValueChanged Changed;

        //public void Method1(Func<int, int, string> del)
        //{
        //    //del()
        //}

        public void Method1(string s)
        {
            EventArgs args = new EventArgs();
            Changed?.Invoke(this, args);
        }
        public void Method2(string s)
        {
            EventArgs args = new EventArgs();
            Changed?.Invoke(this, args);
        }

        public void Exevute()
        {
            DemoDelegate del = Method1;
            del("Test");

            del = Method2;
            del("Method2");

            var x = DeleDemo(delegate
            {
                return 100;
            });

            var s = DeleDemo(delegate
            {
                return 200;
            });

            MyClass lib = new MyClass();
            
            
        }

        public int DeleDemo(DemoDelegate2 del)
        {
            return del();
        }

    }

    public class MyClass : DemoLib
    {
        public delegate void Changes(string message);
        public event Changes Changed;
        public void Test2()
        {

        }
    }
}
