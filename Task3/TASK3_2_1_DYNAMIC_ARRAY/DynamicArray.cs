using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TASK3_2_1_DYNAMIC_ARRAY
{
    public class DynamicArray<T> :IEnumerable, IEnumerable<T>, ICloneable, IDisposable, IEnumerator
    {
        internal int CurIndex = -1;

        internal T[] array;
        public DynamicArray()
        {
            array = new T[8];
            ArrayCount = 0;
        }
        public DynamicArray(int arrayCapacity)
        {
            if (arrayCapacity <= 0)
                throw new ArgumentException("The capacity of the array must be a positive number");

            array = new T[arrayCapacity];
            ArrayCount = 0;
        }

        public DynamicArray(IEnumerable<T> sourceCollection)
        {
            if (sourceCollection == null)
                throw new ArgumentNullException("The Collection cannot be null");

            int i = 0;
            foreach (var item in sourceCollection)
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
            set
            {
                if (Length <= value || value < 0)
                    throw new ArgumentOutOfRangeException("An incorrect value for the capacity of the array");
                else
                if (array.Length == 0)
                {
                    array = new T[value];
                }
                else
                {
                    T[] newArray = array;
                    array = new T[value];
                    newArray.CopyTo(array, 0);
                }

            }
        }

        public T this[int index]
        {
            get
            {
                if (index < -ArrayCount || index > ArrayCount - 1)
                    throw new ArgumentOutOfRangeException("The index of element is outside the array boundaries");
                else
                    if (index < 0)
                    return array[index + ArrayCount];
                else
                    return array[index];
            }
            set
            {
                if (index < -ArrayCount || index > ArrayCount - 1)
                    throw new ArgumentOutOfRangeException("The index of element is outside the array boundaries");
                else
                    if (index < 0)
                    array[index + ArrayCount] = value;
                else
                    array[index] = value;
            }
        }

        public void ExpendTheArray(int newCapacity)
        {
            T[] newArray = new T[newCapacity];
            array.CopyTo(newArray, 0);
            array = newArray;
        }
        public void Add(T objectToAdd)
        {
            if (objectToAdd == null)
                throw new ArgumentNullException("The object to be added cannot be null");

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
                throw new ArgumentNullException("The collection cannot be null");

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
                    array[i] = array[i + 1];
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
                throw new ArgumentOutOfRangeException("The index of the inserted element is outside the array boundaries");
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

        public IEnumerator<T> GetEnumerator()
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

        public object Clone()
        {
            T[] copyArray = new T[Capacity];

            for (int i=0; i < array.Length; i++)
            {
                copyArray[i] = array[i];
            }
            return new DynamicArray<T>(copyArray);
        }


        public T[] ToArray()
        {
            T[] ordinaryArray = new T[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                ordinaryArray[i] = array[i];
            }
            return ordinaryArray;
        }
      
        public T Current
        {
            get
            {
                return array[CurIndex];
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

       public virtual bool MoveNext()
        {
            if (CurIndex == array.Length - 1)
            {
                Reset();
                return false;
            }
            CurIndex++;
            return true;
        }

        public virtual void Reset()
        {
            CurIndex = -1;
        }
        
    }
}
