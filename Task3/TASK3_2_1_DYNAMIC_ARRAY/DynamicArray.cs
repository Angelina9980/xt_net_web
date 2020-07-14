using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace TASK3_2_1_DYNAMIC_ARRAY
{
    class DynamicArray<T> : IEnumerable <T>
    {
        private T[] array;
        public DynamicArray()
        {
            array = new T[8];
            ArrayCount = 0;
        }

        public DynamicArray(int arrayCapacity)
        {
            if (arrayCapacity <= 0)
                throw new ArgumentException("The array capacity must be a positive number");
            
            array = new T[arrayCapacity];
            ArrayCount = 0; 
        }

        public DynamicArray(IEnumerable <T> sourceCollection)
        {
            if (sourceCollection == null)
                throw new ArgumentNullException();

            int i = 0;
            foreach(var item in sourceCollection)
            {
                array[i] = item; 
                i++;
                ArrayCount++;
            }
        }
        public int ArrayCount { get; private set; }
        public int Length
        {
            get
            {
                return ArrayCount;
            }
        }
        public int Capacity
        {
            get
            {
                return array.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index > Capacity)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                return array[index];
            }
            set
            {
                if (index > Capacity)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                    array[index] = value;
            }
        }

        public void ExpendTheArray(int newCapacity)
        {
            T[] newArray = new T [newCapacity];
            array.CopyTo(newArray,0);
            array = newArray;
        }
        public void Add(T objectToAdd)
        {
            if (objectToAdd == null)
                throw new ArgumentNullException();

            if (ArrayCount == Capacity)
            {
                ExpendTheArray(ArrayCount * 2);
            }

            array[ArrayCount] = objectToAdd;
            ArrayCount++;
        }

        public void AddRange(IEnumerable<T> sourceCollection)
        {
            if (sourceCollection == null)
                throw new ArgumentNullException();

            int collectionSize = sourceCollection.Count();

            if (collectionSize + ArrayCount > Capacity)
               ExpendTheArray(collectionSize + ArrayCount);

            foreach (var item in sourceCollection)
            {
                array[ArrayCount] = item;
                ArrayCount++;
            }

        }

        public bool Remove(T itemToDelete)
        {
            var indexToDelete = Array.IndexOf(array, itemToDelete, 0, ArrayCount);

            if (indexToDelete < 0)
                return false;

            else {
                for (var i = indexToDelete; i < Capacity - 1; i++)
                {
                    array[i] = array[i+1];
                }
                ArrayCount--;
                return true;
            }
        }

        public bool Insert(T itemToInsert, int indexToInsert)
        {
            if (indexToInsert < 0 || indexToInsert >= ArrayCount)
            {
                return false;
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                if (ArrayCount == Capacity)
                {
                    ExpendTheArray(ArrayCount * 2);
                }

                for (var i = ArrayCount; i > indexToInsert; i--)
                {
                    array[i] = array[i - 1];
                }

                array[indexToInsert] = itemToInsert;
                ArrayCount++;
                return true;
            }
        }

        public IEnumerator <T> GetEnumerator ()
        {
            foreach (T arrayObject in array)
            {
                yield return arrayObject;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
