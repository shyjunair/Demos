using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    class Program
    {
        static int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        static string[] Month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\n");
                Console.WriteLine("****************************************");
                Console.WriteLine("Print months contains 'ary'");
                var months = from m in Month
                             where m.Contains("ary")
                             select m;
                foreach (var item in months)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("****************************************");
                //Console.WriteLine("\n");
                Console.WriteLine("Print numbers between 2 and 8");
                var nm = from n in Numbers
                         where n > 2 && n < 8
                         select n;
                foreach (var item in nm)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("****************************************");

                Console.WriteLine("Print students order by name");
                var students = Student.Students();
                var res = students.OrderBy(x => x.Name).ToList();
                foreach (var item in res)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("****************************************");
                Console.WriteLine("Print students whos name starting with 'A'");
                res = students.Where(x => x.Name.StartsWith("a", StringComparison.InvariantCultureIgnoreCase)).ToList();
                foreach (var item in res)
                {
                    Console.WriteLine(item.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
