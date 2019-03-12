using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class SoftwareCollection : ICollection<ASoftware>
    {
        private List<ASoftware> _softwares = new List<ASoftware>();

        #region Реализация ICollection<T>
        public int Count => _softwares.Count;
        public bool IsReadOnly => false;

        public void Add(ASoftware item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _softwares.Add(item);
        }

        public void Clear()
        {
            _softwares.Clear();
        }

        public bool Contains(ASoftware item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return _softwares.Contains(item);
        }

        public void CopyTo(ASoftware[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            _softwares.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ASoftware> GetEnumerator()
        {
            return _softwares.GetEnumerator();
        }

        public bool Remove(ASoftware item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return _softwares.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _softwares.GetEnumerator();
        } 
        #endregion

        /// <summary>
        /// Сортировка
        /// </summary>
        public void Sort()
        {
            _softwares.Sort();
        }

        


        /// <summary>
        /// Получение коллекции нужного типа программ
        /// </summary>
        /// <typeparam name="T">тип программ в коллекции</typeparam>
        /// <param name="type">искомый тип программ</param>
        /// <returns>коллекции нужного типа программ</returns>
        public List<T> GetSoftwaresByType<T>(Type type) where T : class
        {
            return _softwares.Where(s => s.GetType().Equals(type))
                             .Select(s => s as T)
                             .ToList();
        }


        public IEnumerable<T> GetSoftwaresByType<T>() where T : class
        {
            foreach (var soft in _softwares)
            {
                if (soft is T)
                {
                    yield return soft as T;
                }
            }
        }

    }
}
