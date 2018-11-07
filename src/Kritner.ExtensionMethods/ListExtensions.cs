using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.ExtensionMethods
{
    /// <summary>
    /// <see cref="IList{T}"/> extensions.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Add object to <see cref="IList{T}"/> only when not null.
        /// </summary>
        /// <typeparam name="T">The type contained within the <see cref="List{T}"/>.</typeparam>
        /// <param name="obj">The <see cref="List{T}"/>.</param>
        /// <param name="item">The item to potentially add.</param>
        public static void AddIfNotNull<T>(this IList<T> obj, T item)
        {
            if (item == null)
            {
                return;
            }

            obj.Add(item);
        }
    }
}
