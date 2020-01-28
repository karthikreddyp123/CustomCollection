using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollection
{
    class CustomList : IList
    {
        object[] array;
        int count = 0;
        object[] tmp;
        public CustomList()
        {
            array = new object[0];
           // Console.WriteLine(array.Length);
        }
        public CustomList(int size)
        {

        }
        public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsFixedSize => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public int Add(object value)
        {
            if (count == 0)
            {
                array = new object[4];
            }
            if (count == array.Length)
            {
                tmp = new object[array.Length + array.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    tmp[i] = array[i];
                }
                array = tmp;
            }
            //tmp[tmp.Length - 1] = value;
            //Console.WriteLine("Hello "+array.Length);
            array[count] = value;
            count++;
            return count-1;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            return IndexOf(value) != -1;
        }

        public void CopyTo(Array arr, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            return Array.IndexOf(array, value);
        }

        public void Insert(int index, object value)
        {
            int k = 0;
                 }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
