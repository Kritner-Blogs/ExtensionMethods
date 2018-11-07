using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.ExtensionMethods
{
    /// <summary>
    /// <see cref="IEnumerable{T}"/> extension methods.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Attempts to find the first item in <see cref="items"/> 
        /// meeting <see cref="Predicate{T}"/>. 
        /// 
        /// Returns the <see cref="true"/> when item found, 
        /// <see cref="false"/> when not.
        /// 
        /// Found result is contained within out parameter <see cref="result"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="predicate"></param>
        /// <param name="result"></param>
        /// <returns><see cref="true"/> when item found. <see cref="false"/> otherwise.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <see cref="items"/> or <see cref="Predicate{T}"/> is null.
        /// </exception>
        public static bool TryFirst<T>(
            this IEnumerable<T> items, 
            Func<T, bool> predicate, 
            out T result
        )
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            result = default(T);
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    result = item;
                    return true;
                }
            }
            return false;
        }
    }
}
