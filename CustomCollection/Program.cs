using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList cl = new CustomList();
            Console.WriteLine(cl.Add(10));
            Console.WriteLine(cl.Add(20));
            Console.WriteLine(cl.Add(30));
            Console.WriteLine(cl.Add(40));
            Console.WriteLine(cl.Add(50));
            Console.WriteLine(cl.Contains(10));
            Console.WriteLine(cl.IndexOf(10));
            Console.ReadLine();
        }
    }
}
