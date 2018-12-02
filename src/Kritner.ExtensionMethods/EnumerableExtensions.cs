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
        /// Attempts to find the first item in items.
        /// meeting <see cref="Predicate{T}"/>. 
        /// 
        /// Returns the true when item found, false when not.
        /// 
        /// Found result is contained within out parameter result.
        /// </summary>
        /// <typeparam name="T">The generic enumerable type.</typeparam>
        /// <param name="items">The items to enumerate.</param>
        /// <param name="predicate">The predicate to search for within items.</param>
        /// <param name="result">The result (when found).</param>
        /// <returns>true when item found, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when items or predicate is null.
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
