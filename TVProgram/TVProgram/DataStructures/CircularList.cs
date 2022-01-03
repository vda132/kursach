using System.Collections;
using System.Collections.Generic;

namespace TVProgram.DataStructures
{
    /// <summary>
    /// Class to manipulate with data 
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    public class CircularList<T> : IEnumerable<T>
    {
        private List<T> collection = new();

        public CircularList()
        {
        }

        public CircularList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                this.collection.Add(item);
        }

        public CircularList(T[] array)
        {
            foreach (var item in array)
                this.collection.Add(item);
        }

        public T GetElement(T item)
        {
            return collection.Find(x => x.Equals(item));
        }

        public IEnumerable<T> GetElementsBetween(T left, T right)
        {
            // Check input data
            // If data is incorrect return empty list
            if (left is null || right is null ||
                !collection.Contains(left) ||
                !collection.Contains(right))
                return new List<T>();

            var result = new List<T>();

            var leftIndex = collection.FindIndex(x => x.Equals(left));
            var rightIndex = collection.FindIndex(x => x.Equals(right));

            if (leftIndex == rightIndex)
            {
                result.Add(collection[leftIndex]);
                return result;
            }

            if (leftIndex < rightIndex)
            {
                for (int i = leftIndex; i <= rightIndex; ++i)
                    result.Add(collection[i]);
                return result;
            }

            for (int i = leftIndex; i < collection.Count; ++i)
                result.Add(collection[i]);

            for (int i = 0; i <= rightIndex; ++i)
                result.Add(collection[i]);

            return result; 
        }

        public void Add(T item)
        {
            collection.Add(item);
        }

        public void Remove(T item)
        {
            collection.Remove(item);
        }

        public bool Contains(T item)
        {
            return collection.Contains(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }
    }
}
