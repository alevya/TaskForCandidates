using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Task2
{
    /// <summary>
    /// Структура для пары чисел
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Pair<T> where T : struct
    {
        private readonly T _p1;
        private readonly T _p2;

        public Pair(T p1, T p2)
        {
            _p1 = p1;
            _p2 = p2;
        }

        public override string ToString()
        {
            return _p1 + "," + _p2;
        }
    }

    public class AlgorithmFind<T> where T : struct
    {
        /// <summary>
        /// Метод поиска в коллекции inData пар чисел, которые в сумме равны x.
        /// Возвращает коллекцию найденных пар. 
        /// </summary>
        /// <param name="inData"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static IEnumerable<Pair<T>> GetPairs(IEnumerable<T> inData, T x)
        
        {
            var result = new List<Pair<T>>();
            var typeCode = Type.GetTypeCode(typeof(T));
            switch (typeCode)
            {
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    break;
                default:
                    return result;
            }

            if (inData == null || !inData.Any()) return result;

            var htSet = new HashSet<T>();
            foreach (dynamic item in inData)
            {
                var t = (T)(x - item);
                if (htSet.Contains(t))
                {
                    result.Add(new Pair<T>(item, t));
                }
                else
                {
                    htSet.Add(item);
                }
            }
            return result;
        }
    }
}
