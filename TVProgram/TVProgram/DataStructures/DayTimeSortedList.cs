using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TVProgram.Models;

namespace TVProgram.DataStructures
{
    class DayTimeSortedList<T> : IEnumerable<T> where T : DisplayModels.TVProgram
    {
        private T[] data;
        
        public int Count { get => data.Length; }

        public DayTimeSortedList()
        {
            data = new T[0];
        }

        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        public bool TryAdd(T item)
        {
            if (!Models.DayOfWeek.CheckDayOfWeek(item.DayOfWeek)) return false;

            var temp = new T[data.Length + 1];

            bool isAdded = false;
            for (int i = 0; i < data.Length; ++i)
            {
                if (Models.DayOfWeek.Greater(item.DayOfWeek, data[i].DayOfWeek))
                {
                    AddTo(ref temp, i);
                }
                else if (Models.DayOfWeek.Equal(item.DayOfWeek, data[i].DayOfWeek))
                {
                    if (item.Time.GreaterTo(data[i].Time))
                    {
                        AddTo(ref temp, i);
                    }
                    else if (item.Time.EqualTo(data[i].Time))
                    {
                        AddTo(ref temp, i, item, ref isAdded);
                    }
                    else
                    {
                        AddTo(ref temp, i, item, ref isAdded);
                    }
                }
                else if (Models.DayOfWeek.Less(item.DayOfWeek, data[i].DayOfWeek))
                {
                    AddTo(ref temp, i, item, ref isAdded);
                }
            }

            if (!isAdded)
            { 
                temp[^1] = item;
                isAdded = true;
            }

            data = temp;
            return isAdded;
        }

        private void AddTo(ref T[] temp, int index)
        {
            temp[index] = data[index];
        }

        private void AddTo(ref T[] temp, int index, T item, ref bool isAdded)
        {
            if (!isAdded)
            {
                temp[index] = item;
                isAdded = true;
            }
            temp[index + 1] = data[index];
        }

        public bool Remove(T item)
        {
            var temp = new T[data.Length - 1];

            bool isRemoved = false;
            for (int i = 0; i < data.Length; ++i)
            {
                if (item.Equals(data[i]))
                {
                    isRemoved = true;
                    continue;
                }

                if (isRemoved)
                    temp[i] = data[i + 1];
                else
                    temp[i] = data[i];
            }

            return isRemoved;
        }

        public List<T> ToList()
        {
            var result = new List<T>();
            foreach (var item in data)
                result.Add(item);
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}
