using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Utility
{
    class SGLArrayList<T>
    {
        private T[] Array;
        private int Index;

        /// <summary>
        /// Constructor for the SGLArrayList.
        /// </summary>
        public SGLArrayList()
        {
            this.Array = new T[1];
            this.Index = 0;
        }
        /// <summary>
        /// Adds an element to the SGLArrayList.
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if (this.Array.Length - 1 == this.Index)
            {
                T[] NewArray = new T[(this.Array.Length * 3) / 2 + 1];
                for (int index = 0; index < this.Array.Length; index++)
                {
                    NewArray[index] = Array[index];
                }
                this.Array = NewArray;
            }
            this.Array[Index] = data;
            this.Index = this.Index + 1;
        }
        /// <summary>
        /// Replaces the element at the given index, with the given element.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void Set(int index, T data)
        {
            this.Array[index] = data;
        }
        /// <summary>
        /// Gets a particular element from the ArrayList given an index.
        /// </summary>
        /// <param name="index"></param>
        public T Get(int index)
        {
            return this.Array[index];
        }
        /// <summary>
        /// Returns the given element from the SGLArrayList
        /// if and only if the array contains the same referenced element.
        /// (this should be used with caution in comparison to using an index to get an element.)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Get(T data)
        {
            for (int index = 0; index < this.Index; index++)
            {
                if (Object.ReferenceEquals(Array[index], data))
                {
                    return Array[index];
                }
            }
            return default(T);
        }
        /// <summary>
        /// Returns the index of the object if it is located within the 
        /// the SGLArrayList. Will return -1 if the object was not found
        /// within the list.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int IndexOf(T data)
        {
            for (int index = 0; index < this.Index; index++)
            {
                if (Object.ReferenceEquals(Array[index], data))
                {
                    return index;
                }
            }
            return -1;
        }
        /// <summary>
        /// Deletes a particular element from the SGLArrayList given an index.
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            T[] NewArray = new T[this.Array.Length - 1];

            for (int otherIndex = 0, secondOtherIndex = 0; otherIndex < this.Array.Length; otherIndex++)
            {
                if (otherIndex != index)
                {
                    NewArray[secondOtherIndex] = this.Array[otherIndex];
                    secondOtherIndex++;
                }
            }
            this.Index = this.Index - 1;
            this.Array = NewArray;
        }
        /// <summary>
        /// If and only if the given element has the same
        /// reference as an element in the SGLArrayList, the object with the same
        /// reference will be deleted.
        /// </summary>
        /// <param name="data"></param>
        public void Delete(T data)
        {
            T[] NewArray = new T[this.Array.Length - 1];

            for (int otherIndex = 0, secondOtherIndex = 0; otherIndex < this.Array.Length; otherIndex++)
            {
                if (!Object.ReferenceEquals(Array[otherIndex], data))
                {
                    NewArray[secondOtherIndex] = this.Array[otherIndex];
                    secondOtherIndex++;
                }
            }
            this.Index = this.Index - 1;
            this.Array = NewArray;
        }
        /// <summary>
        /// Retrieves the current size of the SGLArrayList.
        /// </summary>
        /// <returns></returns>
        public int Length()
        {
            return this.Index;
        }
        /// <summary>
        /// Returns true, if and only if an object within this collection holds ths same
        /// HashCode as the given object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Contains(T data)
        {
            for (int index = 0; index < this.Index; index++)
            {
                if (Object.ReferenceEquals(Array[index], data))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Given an index, place the given element at the index.
        /// All elements including the element that had been replaced
        /// will have their index increases by one.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        public void Insert(int index, T data)
        {
            int Flag = 0;
            T[] Temp = new T[this.Array.Length + 1];
            // Copying all elements of the current arry to the new array until wee get to the index
            for (int position = 0; position < index; position++)
            {
                Temp[position] = this.Array[position];
                // Adds 

                if (position == index - 1)
                {
                    Flag = position + 2;
                    Temp[position + 1] = data;
                }
            }
            for (int position = Flag; position < Temp.Length - 1; position++)
            {
                Temp[position] = this.Array[position - 1];
                if (position == index - 1)
                {
                    Temp[index] = this.Array[index - 2];
                }
            }
            this.Index = this.Index + 1;
            this.Array = Temp;
        }
        /// <summary>
        /// Returns true if and only if the SGLArrayList length is of size zero.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (Array.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // TODO trim method on raw size.
        /// <summary>
        /// Method that return a soft copy of given SGLArrayList
        /// Where the new list will share the references of old values with 
        /// given lists copys.
        /// </summary>
        /// <returns></returns>
        public SGLArrayList<T> SoftCopy()
        {
            SGLArrayList<T> newCopy = new SGLArrayList<T>();
            for (int index = 0; index < this.Length(); index++)
            {
                newCopy.Add(this.Get(index));
            }
            return newCopy;
        }
        /// <summary>
        /// Returns a string representation of the collection.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "[" + StringForm() + "]";
        }

        private string StringForm()
        {
            string arg = "";
            for (int index = 0; index < this.Index; index++)
            {
                arg = arg + (Array[index].ToString().Length < 1 ? "" : (arg.Length < 1 ? "" : ", ")) + Array[index].ToString();
            }
            return arg;
        }
    }
}
