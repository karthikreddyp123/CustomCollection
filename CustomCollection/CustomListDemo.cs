using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollection
{
    class CustomListDemo
    {
        static void Main(string[] args)
        {
            CustomList cl = new CustomList();
            cl.Add(10);
            cl.Add(20);
            cl.Add(50);
            cl.Add(60);
            cl.Add(60);
            cl.Add(60);
            cl.Add(60);
            cl.Add(10);
            cl.Add(20);
            cl.Add(50);
            cl.Add(60);
            cl.Add(60);
            cl.Add(60);
            cl.Add(60);
            cl.Add(100);
            cl.Insert(2, 100);
            cl.Remove(10);
            cl.RemoveAt(1);
            Console.WriteLine("Contains:" + cl.Contains(60));
            Console.WriteLine("Index:" + cl.find(50));
            Console.WriteLine(cl.Get(1));
            Console.WriteLine("Count:" + cl.Count);
            Console.WriteLine("Capacity:" + cl.Capacity);
            cl.Reverse();
            Console.WriteLine("After Reversing:");
            foreach (object i in cl)
            {
                Console.WriteLine(i);
            }
            cl.Sort();
            Console.WriteLine("AfterSorting");
            foreach (object i in cl)
            {
                Console.WriteLine("Sorted:" + i);
            }

            Console.ReadLine();
            
        }     
    }
}
