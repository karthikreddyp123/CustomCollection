using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollection
{
   public class CustomList : IList,IEnumerable
    {

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ArrayListEnum GetEnumerator()
        {
            return new ArrayListEnum(this);
        }
        //Global array of objects initialization
        object[] array;
        int count = 0;
        //Constructor 
        public CustomList()
        {
            array = new object[0];
           // Console.WriteLine(array.Length);
        }
        //Constructor with size parameter.
        public CustomList(int size)
        {
            array = new object[size];
        }
        
        public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsReadOnly => throw new NotImplementedException();
        /// <summary>
        /// This method returns Capacity of CustomList
        /// </summary>
        public int Capacity
        {
            get => array.Length;
        }

        public bool IsFixedSize => throw new NotImplementedException();
        /// <summary>
        /// This method returns Count of CustomList
        /// </summary>
        public int Count
        {
            get => this.count;
        }

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();
        /// <summary>
        /// This method adds an element into CustomList
        /// </summary>
        public int Add(object value)
        {
            object[] tmp;

            if (this.count == 0)
            {
                array = new object[4];
            }
            if (this.count == array.Length)//increasing size of Customlist
            {
                tmp = new object[array.Length + array.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    tmp[i] = array[i];
                }
                array = tmp;
            }
            array[this.count] = value;
            this.count++;
            return this.count-1;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// This method returns boolean value(true) if given value is present in CustomList
        /// </summary>
        public bool Contains(object value)
        {
            return IndexOf(value) != -1;
        }

        public void CopyTo(Array arr, int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method returns the index of given element in CustomList
        /// </summary>
        public int IndexOf(object value)
        {
            return Array.IndexOf(array, value);
        }
        /// <summary>
        /// This method inserts an element into the CustomList at specified Index.
        /// </summary>
        public void Insert(int index, object value)
        {
            object[] tmp;

            if (index < 0 && index > array.Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
      
                if (this.count == array.Length)
                {
                    tmp = new object[2 * array.Length];
                }
                else
                {
                    tmp = new object[array.Length];
                }
                for(int i = 0; i < index; i++)
                {
                    tmp[i] = array[i];
                }
      
                tmp[index] = value;
                for (int i = index; i < count; i++)
                {
                    tmp[i + 1] = array[i];
                }
                array = tmp;
                tmp = null;
                this.count++;
            }
        }
        /// <summary>
        /// This method removes given element from the CustomList
        /// </summary>
        public void Remove(object value)
        {
            object[] tmp;
            int flag = 0;
            tmp = new object[array.Length];
            for (int i = 0, j = 0; i < array.Length && j < tmp.Length; i++,j++)
            {
                //Console.WriteLine("!"+array[i]);
                if (value.Equals(array[i])&&flag==0)
                {
                    //Console.WriteLine("Removal");
                    i++;
                    flag = 1;
                }
                tmp[j] = array[i]; 
            }
            array = tmp;
            if (flag == 1) 
            {
                this.count--;
                //Console.WriteLine("done");
            }
        }
        /// <summary>
        /// This method removes an element at specified index from CustomList.
        /// </summary>
        public void RemoveAt(int index)
        {
            object[] tmp;
            if (index < 0 && index > array.Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                int flag = 0;
                tmp = new object[array.Length];
                for (int i = 0, j = 0; i < array.Length && j < tmp.Length; i++, j++)
                {
                    if (i == index && flag == 0)
                    {
                        i++;
                        flag++;
                    }
                    tmp[j] = array[i];
                }
                array = tmp;
                if (flag>0)
                {
                    this.count -= flag;
                }
            }
        }
        /// <summary>
        /// This method searches for a specific element in CustomList.
        /// </summary>
        public int find(object value)
        {
            foreach(object i in array)
            {
                if (value.Equals(i))
                {
                    return IndexOf(i);
                }
                
            }
            return -1;
        }
        /// <summary>
        /// This method returns element at a specific index in CustomList. 
        /// </summary>
        public Object Get(int index)
        {
            if (index < 0 && index > array.Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return array[index];
            }
        }
        /// <summary>
        /// This method sorts the CustomList.
        /// </summary>
        public void Sort()
        {
            Array.Sort(array,0,count);
        }
        public void Reverse()
        {
            //object[] tmp = new object[array.Length];
            //Console.WriteLine(count);
            //Console.WriteLine("In reverse:");
            //foreach(object i in array)
            //{
            //    Console.WriteLine(i);
            //}
            //for (int i = 0, j = count; i > count; i++, j--)
            //{
            //    Console.WriteLine("hello");
            //    tmp[i] = array[j - 1];

            //}
            //array = tmp;   
            Array.Reverse(array, 0, count);
        }
     
    }
    // When you implement IEnumerable, you must also implement IEnumerator.
    public class ArrayListEnum : IEnumerator
    {
        public CustomList _list;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public ArrayListEnum(CustomList list)
        {
            _list = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _list.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Object Current
        {
            get
            {
                try
                {
                    return _list.Get(position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        
    }
}
